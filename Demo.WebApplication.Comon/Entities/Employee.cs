using B1.Demo.WebApplication.Common.Enums;

namespace B1.Demo.WebApplication.Common.Entities
{
    public class Employee
    {
        // Cách tạo ra summary gõ 3 dấu ///
        // Ctrl M O để đóng summary còn mở Ctrl M L 
        // Alt Enter gợi ý code

        /// <summary>
        /// đây là dạng field chỉ có td là đọc gtri k set đc gtri
        /// </summary>
        // private int a;

        /// <summary>
        /// Còn dạng này có thể set gtri và gán gtri 
        /// </summary>
        // public int A { get; set; }

        public Guid EmployeeID { get; set; }

        public string EmployeeCode { get; set; }

        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string CMTND { get; set; }

        public string IssuedBy { get; set; }
        
        public string JobTitle { get; set; }
        
        public string Address { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string PhoneFix { get; set; }
        
        public string Email { get; set; }
        
        public DateTime ModifiedDate { get; set; }
        
        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreateBy { get; set; }
        
        public Guid DepartmentId { get; set; }

    }
}
