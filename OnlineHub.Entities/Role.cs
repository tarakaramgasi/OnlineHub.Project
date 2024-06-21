using Microsoft.AspNetCore.Identity;
namespace OnlineHub.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
