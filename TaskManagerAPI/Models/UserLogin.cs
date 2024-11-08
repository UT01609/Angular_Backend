using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class UserLogin
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Role role { get; set; }


        public enum Role
        {
            Admin=1,
            Editor=2,
            Viewver=3
        }
    }
}
