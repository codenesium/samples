using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("CountryRequirement", Schema="dbo")]
        public partial class CountryRequirement : AbstractEntity
        {
                public CountryRequirement()
                {
                }

                public void SetProperties(
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
                public virtual Country Country { get; set; }
        }
}

/*<Codenesium>
    <Hash>4f959ff4705550767f2a09707258f85d</Hash>
</Codenesium>*/