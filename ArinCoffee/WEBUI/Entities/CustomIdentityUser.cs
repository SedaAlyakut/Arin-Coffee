using Microsoft.AspNetCore.Identity;
using WEBUI.Models;

namespace WEBUI.Entities
{
    public class CustomIdentityUser:IdentityUser<int>
    {
        public string IpAdress { get; set; }

        public static implicit operator UserDetailViewModel(CustomIdentityUser user)
        {
            return new UserDetailViewModel
            {
                IpAdress = user.IpAdress,

            };
        }
    }
}
