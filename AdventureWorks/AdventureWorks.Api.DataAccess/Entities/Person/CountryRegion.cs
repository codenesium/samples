using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("CountryRegion", Schema="Person")]
        public partial class CountryRegion : AbstractEntity
        {
                public CountryRegion()
                {
                }

                public virtual void SetProperties(
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
    <Hash>75d3f2d12148e0431189eda61d84382d</Hash>
</Codenesium>*/