namespace eAppointmentServer.WebAPI.Services;

public static class DefaultCorsPolicy
{
    public static IServiceCollection AddDefaultCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(policy => true)
                    .AllowCredentials();
            });
        });

        return services;
    }
}
