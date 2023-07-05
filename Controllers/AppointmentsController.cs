using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.Data;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorization.Repository.Interfaces;
using RoleBasedAuthorization.Repository.Services;

namespace RoleBasedAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment _user;
        public AppointmentController(IAppointment user)
        {
            _user = user;
        }
        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            return _user.GetAllPatients();
        }
        [HttpGet("{id}")]
        public Appointment GetById(int id)
        {
            return _user.GetPatientById(id);
        }
        [HttpPost]
        public async Task<ActionResult<List<Appointment>>> AddPatient(Appointment user)
        {
            var users = await _user.Addpatient(user);
            return Ok(users);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Appointment>>> DeletePatientById(int id)
        {
            var users = await _user.DeletePatientById(id);
            if (users is null)
            {
                return NotFound("userid not matching");
            }
            return Ok(users);
        }

        [HttpGet("getbyemail")]
        public ActionResult<IEnumerable<Appointment>> GetAppointmentsByDoctorEmail(string doctorEmail)
        {
            var appointments = _user.GetAppointmentsByDoctorEmail(doctorEmail);
            if (appointments == null || !appointments.Any())
            {
                return NotFound();
            }

            return Ok(appointments);
        }



    }
}
