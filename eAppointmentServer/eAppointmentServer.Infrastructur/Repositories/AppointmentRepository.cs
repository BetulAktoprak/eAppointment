using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructur.Context;

namespace eAppointmentServer.Infrastructur.Repositories;
internal sealed class AppointmentRepository : Repository<Appointment, AppDbContext>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext context) : base(context)
    {
    }
}
