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

                public void SetProperties(
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
    <Hash>6e6a2ab46fb46459f7f593320664938b</Hash>
</Codenesium>*/