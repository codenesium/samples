using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("CountryRequirement", Schema="dbo")]
        public partial class CountryRequirement: AbstractEntity
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

                [Column("countryId", TypeName="int")]
                public int CountryId { get; private set; }

                [Column("details", TypeName="text(2147483647)")]
                public string Details { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [ForeignKey("CountryId")]
                public virtual Country Country { get; set; }
        }
}

/*<Codenesium>
    <Hash>92614d02e732978a65a9d5f129c44bba</Hash>
</Codenesium>*/