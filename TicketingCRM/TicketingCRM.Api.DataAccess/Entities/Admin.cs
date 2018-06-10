using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Admin", Schema="dbo")]
        public partial class Admin:AbstractEntity
        {
                public Admin()
                {
                }

                public void SetProperties(
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string password,
                        string phone,
                        string username)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Password = password;
                        this.Phone = phone;
                        this.Username = username;
                }

                [Column("email", TypeName="varchar(128)")]
                public string Email { get; private set; }

                [Column("firstName", TypeName="varchar(128)")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("lastName", TypeName="varchar(128)")]
                public string LastName { get; private set; }

                [Column("password", TypeName="varchar(128)")]
                public string Password { get; private set; }

                [Column("phone", TypeName="varchar(128)")]
                public string Phone { get; private set; }

                [Column("username", TypeName="varchar(128)")]
                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>230d55e1392702b57d4f40087274d6d9</Hash>
</Codenesium>*/