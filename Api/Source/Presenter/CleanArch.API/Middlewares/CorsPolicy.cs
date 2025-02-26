namespace CleanArch.API.Middlewares;

public static class CorsPolicy
{
    public static void AddCorsPolicy(this IServiceCollection self)
    {
        self.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.WithMethods("OPTIONS", "GET", "POST", "PUT", "DELETE");
            });
        });
    }
}