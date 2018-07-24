using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
                public virtual Currency CurrencyNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7f7ba4291da99e81dda6e48fc4e96957</Hash>
</Codenesium>*/