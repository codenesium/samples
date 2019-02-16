using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CurrencyRate", Schema="Sales")]
	public partial class CurrencyRate : AbstractEntity
	{
		public CurrencyRate()
		{
		}

		public virtual void SetProperties(
			int currencyRateID,
			decimal averageRate,
			DateTime currencyRateDate,
			decimal endOfDayRate,
			string fromCurrencyCode,
			DateTime modifiedDate,
			string toCurrencyCode)
		{
			this.CurrencyRateID = currencyRateID;
			this.AverageRate = averageRate;
			this.CurrencyRateDate = currencyRateDate;
			this.EndOfDayRate = endOfDayRate;
			this.FromCurrencyCode = fromCurrencyCode;
			this.ModifiedDate = modifiedDate;
			this.ToCurrencyCode = toCurrencyCode;
		}

		[Column("AverageRate")]
		public virtual decimal AverageRate { get; private set; }

		[Column("CurrencyRateDate")]
		public virtual DateTime CurrencyRateDate { get; private set; }

		[Key]
		[Column("CurrencyRateID")]
		public virtual int CurrencyRateID { get; private set; }

		[Column("EndOfDayRate")]
		public virtual decimal EndOfDayRate { get; private set; }

		[MaxLength(3)]
		[Column("FromCurrencyCode")]
		public virtual string FromCurrencyCode { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(3)]
		[Column("ToCurrencyCode")]
		public virtual string ToCurrencyCode { get; private set; }

		[ForeignKey("FromCurrencyCode")]
		public virtual Currency CurrencyNavigation { get; private set; }

		public void SetCurrencyNavigation(Currency item)
		{
			this.CurrencyNavigation = item;
		}

		[ForeignKey("ToCurrencyCode")]
		public virtual Currency Currency1Navigation { get; private set; }

		public void SetCurrency1Navigation(Currency item)
		{
			this.Currency1Navigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>15c9d63334db2160abbd2e68931d6382</Hash>
</Codenesium>*/