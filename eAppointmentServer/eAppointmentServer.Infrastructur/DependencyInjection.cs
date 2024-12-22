using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructur.Context;
using eAppointmentServer.Infrastructur.Repositories;
using eAppointmentServer.Infrastructur.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eAppointmentServer.Infrastructur;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddIdentity<AppUser, AppRole>(action =>
        {
            action.Password.RequiredLength = 1;
            action.Password.RequireUppercase = false;
            action.Password.RequireLowercase = false;
            action.Password.RequireNonAlphanumeric = false;
            action.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<AppDbContext>());

        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}
