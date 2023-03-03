namespace api.Infrastructure.Extensions
{
    public static class ConfigurationBuilderExtension
    {
        public static string GetDefaultConnectionString(
            this IConfiguration configuration)
            => configuration.GetConnectionString(CONNECTION_STRING);
    }
}
