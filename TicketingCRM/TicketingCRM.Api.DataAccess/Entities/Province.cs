using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Province", Schema="dbo")]
        public partial class Province : AbstractEntity
        {
                public Province()
                {
                }

                public virtual void SetProperties(
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
                public virtual Country CountryNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>cf480c2a0cc97e9da5a1d40623bb29ff</Hash>
</Codenesium>*/