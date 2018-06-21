using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Admin", Schema="dbo")]
        public partial class Admin : AbstractEntity
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

                [Column("email")]
                public string Email { get; private set; }

                [Column("firstName")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("lastName")]
                public string LastName { get; private set; }

                [Column("password")]
                public string Password { get; private set; }

                [Column("phone")]
                public string Phone { get; private set; }

                [Column("username")]
                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9931026a5a58aa7f890bebe9714a3570</Hash>
</Codenesium>*/