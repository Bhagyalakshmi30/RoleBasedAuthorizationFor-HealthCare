using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.Data;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorization.Repository.Interfaces;

namespace RoleBasedAuthorization.Repository.Services
{
    public class AppointmentService:IAppointment
    {
        private readonly RoleBasedAuthorizationDbContext _UserContext;

        public AppointmentService(RoleBasedAuthorizationDbContext context)
        {
            _UserContext = context;
        }
        //GetAllPatient
        public IEnumerable<Appointment> GetAllPatients()
        {
            return _UserContext.Appointments.ToList();
        }
        //GetPatientById
        public Appointment GetPatientById(int User_Id)
        {
            return _UserContext.Appointments.FirstOrDefault(x => x.AppointmentId == User_Id);
        }
        ////PostPatient
        public async Task<List<Appointment>> Addpatient(Appointment user)
        {
            _UserContext.Appointments.Add(user);
            await _UserContext.SaveChangesAsync();

            return await _UserContext.Appointments.ToListAsync();
        }

        //Delete
        public async Task<List<Appointment>?> DeletePatientById(int id)
        {
            var users = await _UserContext.Appointments.FindAsync(id);
            if (users is null)
            {
                return null;
            }
            _UserContext.Remove(users);
            await _UserContext.SaveChangesAsync();
            return await _UserContext.Appointments.ToListAsync();
        }

        public IEnumerable<Appointment> GetAppointmentsByDoctorEmail(string doctorEmail)
        {
            return _UserContext.Appointments.Where(a => a.DoctorsEmail == doctorEmail);
        }
    }
}


