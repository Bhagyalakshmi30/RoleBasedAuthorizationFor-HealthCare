using RoleBasedAuthorization.Models;

namespace RoleBasedAuthorization.Repository.Interfaces
{
    public interface IAppointment
    {
        IEnumerable<Appointment> GetAllPatients();
        Appointment GetPatientById(int User_Id);
        Task<List<Appointment>> Addpatient(Appointment user);
        Task<List<Appointment>?> DeletePatientById(int id);
        public IEnumerable<Appointment> GetAppointmentsByDoctorEmail(string doctorEmail);
    }
}
