using static TaskManagerAPI.Models.UserLogin;

namespace TaskManagerAPI.DTO.Responce
{
    public class UserLoginResponce
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
