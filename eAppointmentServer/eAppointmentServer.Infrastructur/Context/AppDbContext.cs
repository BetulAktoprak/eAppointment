using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace eAppointmentServer.Infrastructur.Context;
internal sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>, IUnitOfWork
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Doctor>? Doctors { get; set; }
    public DbSet<Patient>? Patients { get; set; }
    public DbSet<Appointment>? Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
