namespace CodedMVC.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Nam { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HDate { get; set; }
        public bool IsActive {  get; set; }
        public bool IsDeleted {  get; set; }
    }
}
