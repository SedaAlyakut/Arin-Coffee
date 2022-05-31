using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites;


namespace Entities.Models
{
    [Table("User", Schema = "dbo")]

    public partial class User : IEntity
    {
        [Key]
        public int UsersId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public int Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LoginDate { get; set; }
    }
}
