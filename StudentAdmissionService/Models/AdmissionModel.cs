using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmissionService.Models
{
    public class AdmissionModel
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public DateTime DateofJoining { get; set; }
    }
}
