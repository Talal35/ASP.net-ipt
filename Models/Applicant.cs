using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPT1.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(150)]
        public string Name { get; set; } = "";

        
        [StringLength(10)]
        public string Gender { get; set; } = "";

        [Required]
        [Range(20, 55, ErrorMessage = "No employee under age 20 allowed")]
        [DisplayName("Age in Years")]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Job_Status { get; set; } = "";

        [Required]
        [Range(1, 100, ErrorMessage = "Enter Work per Hour")]
        [DisplayName("Total Hours of work")]
        public int work_per_hour { get; set; }

        [Required]
        [Range(1, 10000000, ErrorMessage = "Enter Correct Wage")]
        [DisplayName("Wage")]
        public int Wage { get; set; }

        [Required]
        [Range(1, 25, ErrorMessage = "Currently,We Have no Positions Vacant for Your Experience")]
        [DisplayName("Total Experience in Years")]
        public int TotalExperience { get; set; }



        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();//detail very important


        
       /*


           public string PhotoUrl { get; set; }
       
             [Required(ErrorMessage = "Please choose the Profile Photo")]
            [Display(Name = "Profile Photo")]
            [NotMapped]
           public IFormFile ProfilePhoto { get; set; }

        */
    }
}
