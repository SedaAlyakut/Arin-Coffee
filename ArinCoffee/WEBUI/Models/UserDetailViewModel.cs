
using WEBUI.Entities;
using WEBUI.Entities.Validations;

namespace WEBUI.Models
{
    public class UserDetailViewModel
    {
        public string IpAdress { get; set; }

        public static implicit operator CustomIdentityUser(UserDetailViewModel userDetail)
        {
            return new CustomIdentityUser
            {
                IpAdress = userDetail.IpAdress,
            };
        }
    }
}
