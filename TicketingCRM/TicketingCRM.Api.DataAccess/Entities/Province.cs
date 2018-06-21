using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Province", Schema="dbo")]
        public partial class Province : AbstractEntity
        {
                public Province()
                {
                }

                public void SetProperties(
                        int countryId,
                        int id,
                        string name)
                {
                        this.CountryId = countryId;
                        this.Id = id;
                        this.Name = name;
                }

                [Column("countryId")]
                public int CountryId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [ForeignKey("CountryId")]
                public virtual Country Country { get; set; }
        }
}

/*<Codenesium>
    <Hash>1fda29fa6ad5c9bad0eeecaca9487597</Hash>
</Codenesium>*/