using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Customer", Schema="dbo")]
        public partial class Customer: AbstractEntity
        {
                public Customer()
                {
                }

                public void SetProperties(
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string phone)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Phone = phone;
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

                [Column("phone", TypeName="varchar(128)")]
                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>79c73bcd2d49a04b7cfa754c0333806a</Hash>
</Codenesium>*/