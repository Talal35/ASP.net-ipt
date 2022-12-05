using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IPT1.Models;


namespace IPT1.Data
{
    public class IPTDBcontext:DbContext
    {
        public IPTDBcontext(DbContextOptions<IPTDBcontext> options) : base(options)
        {
        }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }

    }
}
