using System;
using System.Collections;
using System.Text;

namespace PeteFest.Infrastructure.Logging
{
    public class LoggingBase
    {
        public string GetExceptionAsString(Exception ex)
        {
            var builder = new StringBuilder();
            ExceptionAsString(ex, builder, 0);
            return builder.ToString();
        }

        private void ExceptionAsString(Exception exception, StringBuilder builderToFill, int level)
        {
            var indent = new string(' ', level);

            if (level > 0)
            {
                builderToFill.AppendLine(indent + "=== INNER EXCEPTION ===");
            }

            Action<string> append = (prop) =>
            {
                var propInfo = exception.GetType().GetProperty(prop);
                var val = propInfo.GetValue(exception);

                if (val != null)
                {
                    builderToFill.AppendFormat("{0}{1}: {2}{3}", indent, prop, val.ToString(), Environment.NewLine);
                }
            };

            append("Message");
            append("HResult");
            append("HelpLink");
            append("Source");
            append("StackTrace");
            append("TargetSite");

            foreach (DictionaryEntry de in exception.Data)
            {
                builderToFill.AppendFormat("{0} {1} = {2}{3}", indent, de.Key, de.Value, Environment.NewLine);
            }

            if (exception.InnerException != null)
            {
                ExceptionAsString(exception.InnerException, builderToFill, ++level);
            }
        }
    }
}
