using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Destination", Schema="dbo")]
        public partial class Destination: AbstractEntity
        {
                public Destination()
                {
                }

                public void SetProperties(
                        int countryId,
                        int id,
                        string name,
                        int order)
                {
                        this.CountryId = countryId;
                        this.Id = id;
                        this.Name = name;
                        this.Order = order;
                }

                [Column("countryId", TypeName="int")]
                public int CountryId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [Column("order", TypeName="int")]
                public int Order { get; private set; }

                [ForeignKey("CountryId")]
                public virtual Country Country { get; set; }
        }
}

/*<Codenesium>
    <Hash>ae948daf842854f511331c90b57da272</Hash>
</Codenesium>*/