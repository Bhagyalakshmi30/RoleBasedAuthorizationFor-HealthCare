﻿using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuthorization.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientEmail { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateTime? Slot { get; set; }
        public string? Problem { get; set; }
        public string? DoctorsEmail { get; set; } = string.Empty;
        public User? Users { get; set; }




    }
}
