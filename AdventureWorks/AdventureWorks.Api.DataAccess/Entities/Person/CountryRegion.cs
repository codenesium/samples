using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("CountryRegion", Schema="Person")]
        public partial class CountryRegion : AbstractEntity
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
                [Column("CountryRegionCode")]
                public string CountryRegionCode { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7b8a9f519a9deaefaaba402494713e27</Hash>
</Codenesium>*/