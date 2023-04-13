namespace BusinessAdmin.DataAccess.Models
{
    public sealed class AdminDTO
    {
        public AdminDTO(bool isAdmin,bool isPasswd) {
            IsAdmin = isAdmin;
            IsPasswd = isPasswd;
        }
        public bool IsAdmin { get; set; }
        public bool IsPasswd { get; set; }
    }
}
