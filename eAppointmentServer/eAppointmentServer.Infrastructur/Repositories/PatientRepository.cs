using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructur.Context;

namespace eAppointmentServer.Infrastructur.Repositories;
internal sealed class PatientRepository : Repository<Patient, AppDbContext>, IPatientRepository
{
    public PatientRepository(AppDbContext context) : base(context)
    {
    }
}
