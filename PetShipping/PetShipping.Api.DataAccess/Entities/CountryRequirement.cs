using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
        [Table("CountryRequirement", Schema="dbo")]
        public partial class CountryRequirement : AbstractEntity
        {
                public CountryRequirement()
                {
                }

                public virtual void SetProperties(
                        int countryId,
                        string details,
                        int id)
                {
                        this.CountryId = countryId;
                        this.Details = details;
                        this.Id = id;
                }

                [Column("countryId")]
                public int CountryId { get; private set; }

                [Column("details")]
                public string Details { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [ForeignKey("CountryId")]
                public virtual Country CountryNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1e15109c39e158d646b18d4a41104029</Hash>
</Codenesium>*/