using System.ComponentModel.DataAnnotations;

namespace CodedMVC.Models
{
    public class Employee
    {
        [Display(Name = "ID")]
        public int EmployeeId { get; set; }
        [Display(Name = "Name")]
        public string Nam { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        public DateTime HDate { get; set; }
        [Display (Name = "Is active?")]
        public bool IsActive {  get; set; }
        [Display(Name = "Is Deleted?")]
        public bool IsDeleted {  get; set; }
    }
}
