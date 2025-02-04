using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OCS.Business.DependencyResolvers;
using OCS.Common.DTOs.Profiles;
using OCS.Common.Pagination;
using OCS.DataAccess.Concrete.EntityFramework;

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
