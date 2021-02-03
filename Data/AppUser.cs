using Microsoft.AspNetCore.Identity;
using INStudio.Data;
using System.Collections.Generic;
namespace Identity.Models
{
    public class AppUser : IdentityUser
    {
        #nullable enable
        public string? ImageId { get; set; }
        public INMedia? Image { get; set; }

        public string? Facebook { get; set; }
        public string? Description { get; set; }
        public string? JobTitle { get; set; }
        #nullable enable
        public HashSet<Comment>? Comments { get; set; }
        public HashSet<BlogPost>? Posts { get; set; }

    }
}