using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("Province", Schema="dbo")]
        public partial class Province: AbstractEntity
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

                [Column("countryId", TypeName="int")]
                public int CountryId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [ForeignKey("CountryId")]
                public virtual Country Country { get; set; }
        }
}

/*<Codenesium>
    <Hash>fac6bcd93080eb6563b42a3b6dd7f335</Hash>
</Codenesium>*/