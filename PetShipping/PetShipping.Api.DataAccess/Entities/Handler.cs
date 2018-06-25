using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Handler", Schema="dbo")]
        public partial class Handler : AbstractEntity
        {
                public Handler()
                {
                }

                public virtual void SetProperties(
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

                [Column("countryId")]
                public int CountryId { get; private set; }

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
    <Hash>e89cf7ae5a494e07faeeac8469be934a</Hash>
</Codenesium>*/