namespace ShopTLA.Models.DTO
{
    public class UsersDTO
    {
        public string UserName { get; set; } = null!;

        public string PassWord { get; set; } = null!;
    }

    public class RegisterDTO
    {
        public string UserName { get; set; } = null!;

        public string PassWord { get; set; } = null!;
        public string ConfirmPassWord { get; set; } = null!;
    }

    public class ChangePassDTO
    {
        public string Token { get; set; } = null!;
        public string PassWord { get; set; } = null!;
        public string ConfirmPassWord { get; set; } = null!;
    }

    public class CustomerDTO
    {
        public string CusNameDTO { get; set; } = null!;

        public DateTime? CusDateOfBirthDTO { get; set; }

        public string? CusAddressDTO { get; set; }

        public string? CusPhoneDTO { get; set; }

        public string? CusEmailDTO { get; set; }

        public DateTime? CusLastUpdateDTO { get; set; }
    }

    public class EmployeeDTO
    {
        public string EmpNameDTO { get; set; } = null!;

        public DateTime? EmpDateOfBirthDTO { get; set; }

        public string? EmpAddressDTO { get; set; }

        public string? EmpPhoneDTO { get; set; }

        public string? EmpEmailDTO { get; set; }

        public double? EmpSalaryDTO { get; set; }

        public DateTime? EmpLastUpdateDTO { get; set; }
    }
}
