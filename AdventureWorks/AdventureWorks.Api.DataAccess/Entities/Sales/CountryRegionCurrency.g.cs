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
		[MaxLength(3)]
		[Column("CountryRegionCode")]
		public virtual string CountryRegionCode { get; private set; }

		[Key]
		[MaxLength(3)]
		[Column("CurrencyCode")]
		public virtual string CurrencyCode { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[ForeignKey("CurrencyCode")]
		public virtual Currency CurrencyNavigation { get; private set; }

		public void SetCurrencyNavigation(Currency item)
		{
			this.CurrencyNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>ea5885babbd71f9873c37df548ec17ba</Hash>
</Codenesium>*/