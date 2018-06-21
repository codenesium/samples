using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Customer", Schema="dbo")]
        public partial class Customer : AbstractEntity
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

                [Column("email")]
                public string Email { get; private set; }

                [Column("firstName")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("lastName")]
                public string LastName { get; private set; }

                [Column("phone")]
                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1ed06a4c47c923ed69b77485c5f0c98f</Hash>
</Codenesium>*/