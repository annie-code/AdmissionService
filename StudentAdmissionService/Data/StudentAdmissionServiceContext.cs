using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAdmissionService.Models;

namespace StudentAdmissionService.Data
{
    public class StudentAdmissionServiceContext : DbContext
    {
        public StudentAdmissionServiceContext (DbContextOptions<StudentAdmissionServiceContext> options)
            : base(options)
        {
        }

        public DbSet<StudentAdmissionService.Models.AdmissionModel> AdmissionModel { get; set; }
    }
}
