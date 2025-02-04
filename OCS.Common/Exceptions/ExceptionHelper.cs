using System.Diagnostics;
using System.Text;

namespace OCS.Common.Exceptions;

public static class ExceptionHelper
{
    public static string CollectMessages(this Exception exception)
    {
        StringBuilder builder = new();
        builder.Append('N');
        builder.Append(new StackTrace(exception, true).GetFrame(0).GetFileLineNumber());
        builder.Append("-StackTrace: ");
        builder.AppendLine(exception.StackTrace);
        builder.AppendLine("--------------------------------------------");

        do
        {
            builder.Append("Exception type: ");
            builder.AppendLine(exception.GetType().ToString());

            builder.Append("Source: ");
            builder.AppendLine(exception.Source);

            builder.Append("Message: ");
            builder.AppendLine(exception.Message);

            exception = exception.InnerException;
        } while (exception != null);

        return builder.ToString();
    }
}
