namespace UserService.API.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public int IdRole { get; set; }
        public bool IsActive { get; set; }
        public int IdEntryUser { get; set; }
        public DateTime EntryDate { get; set; }
        public int? IdUpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDelete { get; set; }
        public int? IdDeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
