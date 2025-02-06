using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using OCS.Business.DependencyResolvers;
using OCS.Common.DTOs.Profiles;
using OCS.Common.Pagination;
using OCS.DataAccess.Concrete.EntityFramework;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OCSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//TODO: otomatik tüm assembly'leri tanıyan yapıyı olustur
builder.Services.AddAutoMapper(typeof(OrderProfile).Assembly);

builder.Services.AddScoped<IPaginationUriService>(options =>
{
    return new PaginationUriService(options.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Request.Path);
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddControllers(options =>
    {
        IEnumerable<ODataOutputFormatter> outputFormatters =
            options.OutputFormatters.OfType<ODataOutputFormatter>()
                .Where(foramtter => foramtter.SupportedMediaTypes.Count == 0);

        foreach (var outputFormatter in outputFormatters)
            outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
    })
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddOData(opt => opt.Filter().Select().Expand().OrderBy());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//basit seviyede hata yönetimi sağladım.
//middleware yazılarak daha detaylı hata yönetimi yapılabilir.
app.UseExceptionHandler("/error");

app.UseCors(builder =>
{
    var allowedUrls = app.Configuration.GetSection("CORS_URL").Get<string[]>();
    builder.WithOrigins(allowedUrls)
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
