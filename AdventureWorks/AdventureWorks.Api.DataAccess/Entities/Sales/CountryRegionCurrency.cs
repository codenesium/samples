using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("CountryRegionCurrency", Schema="Sales")]
        public partial class CountryRegionCurrency : AbstractEntity
        {
                public CountryRegionCurrency()
                {
                }

                public virtual void SetProperties(
                        string countryRegionCode,
                        string currencyCode,
                        DateTime modifiedDate)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                }

                [Key]
                [Column("CountryRegionCode")]
                public string CountryRegionCode { get; private set; }

                [Column("CurrencyCode")]
                public string CurrencyCode { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [ForeignKey("CurrencyCode")]
                public virtual Currency Currency { get; set; }
        }
}

/*<Codenesium>
    <Hash>e2d1f58ee35ad001a4e6d199f0f66a12</Hash>
</Codenesium>*/