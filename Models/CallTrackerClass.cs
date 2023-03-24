using System.ComponentModel.DataAnnotations;

namespace ASP.NETFinalExamsProject.Models
{
    public class CallTrackerClass
    {
        [Key]
        public int Id { get; set; }
   
        [Required(ErrorMessage = "Please type Employee Name")]
        [Display(Name = "Employee Name")]
        [StringLength(100, ErrorMessage = "The length of the Employee Name is too long")]
        public string EmployeeName { get; set; }

        [Display(Name = "Call Type")]
        public string CallType { get; set; }


        [Display(Name = "Call Duration")]
        public int Duration { get; set; }


        [Display(Name = "Destination Number")]
        public string DestinationNumber { get; set; }


        public DateTime DateTime { get; set; }


        [Display(Name = "Call Cost")]
        public double Cost { get; set; }
        
    }

 
}
