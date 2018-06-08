using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Handler", Schema="dbo")]
        public partial class Handler: AbstractEntity
        {
                public Handler()
                {
                }

                public void SetProperties(
                        int countryId,
                        string email,
                        string firstName,
                        int id,
                        string lastName,
                        string phone)
                {
                        this.CountryId = countryId;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.Id = id;
                        this.LastName = lastName;
                        this.Phone = phone;
                }

                [Column("countryId", TypeName="int")]
                public int CountryId { get; private set; }

                [Column("email", TypeName="varchar(128)")]
                public string Email { get; private set; }

                [Column("firstName", TypeName="varchar(128)")]
                public string FirstName { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("lastName", TypeName="varchar(128)")]
                public string LastName { get; private set; }

                [Column("phone", TypeName="varchar(10)")]
                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6a07bf4e3cf8ecd2a67fce5da586aa0e</Hash>
</Codenesium>*/