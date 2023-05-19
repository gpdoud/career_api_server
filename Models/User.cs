using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace career_api_server.Models {

    [Index("Email", IsUnique = true)]
    public class User {
        public int Id { get; set; } = 0;
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
        [StringLength(50)]
        public string Firstname { get; set; } = string.Empty;
        [StringLength(50)]
        public string Lastname { get; set; } = string.Empty;
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;
        public bool Admin { get; set; } = false;

        public bool Active { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; } = null;
    }
}

