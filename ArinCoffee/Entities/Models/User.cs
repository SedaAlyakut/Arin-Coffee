using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class User
    {
        public int UsersId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
