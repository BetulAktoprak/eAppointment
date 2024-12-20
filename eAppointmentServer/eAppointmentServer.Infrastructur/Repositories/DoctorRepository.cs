using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructur.Context;

namespace eAppointmentServer.Infrastructur.Repositories;
internal sealed class DoctorRepository : Repository<Doctor, AppDbContext>, IDoctorRepository
{
    public DoctorRepository(AppDbContext context) : base(context)
    {
    }
}
