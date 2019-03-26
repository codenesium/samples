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
		public virtual Currency CurrencyCodeNavigation { get; private set; }

		public void SetCurrencyCodeNavigation(Currency item)
		{
			this.CurrencyCodeNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>b536500ac1b215ea68fa423b40e7aeda</Hash>
</Codenesium>*/