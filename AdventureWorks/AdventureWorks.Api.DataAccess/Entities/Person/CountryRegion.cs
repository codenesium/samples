using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("CountryRegion", Schema="Person")]
        public partial class CountryRegion: AbstractEntity
        {
                public CountryRegion()
                {
                }

                public void SetProperties(
                        string countryRegionCode,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Key]
                [Column("CountryRegionCode", TypeName="nvarchar(3)")]
                public string CountryRegionCode { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2084c45717d371b78547403f151c09a8</Hash>
</Codenesium>*/