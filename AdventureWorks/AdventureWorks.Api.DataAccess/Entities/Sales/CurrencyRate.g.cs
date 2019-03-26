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
		public virtual Currency FromCurrencyCodeNavigation { get; private set; }

		public void SetFromCurrencyCodeNavigation(Currency item)
		{
			this.FromCurrencyCodeNavigation = item;
		}

		[ForeignKey("ToCurrencyCode")]
		public virtual Currency ToCurrencyCodeNavigation { get; private set; }

		public void SetToCurrencyCodeNavigation(Currency item)
		{
			this.ToCurrencyCodeNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>7ba9b16190c7761f846de22e304b35ce</Hash>
</Codenesium>*/