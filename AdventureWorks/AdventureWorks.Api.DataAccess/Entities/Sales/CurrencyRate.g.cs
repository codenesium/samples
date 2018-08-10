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
			decimal averageRate,
			DateTime currencyRateDate,
			int currencyRateID,
			decimal endOfDayRate,
			string fromCurrencyCode,
			DateTime modifiedDate,
			string toCurrencyCode)
		{
			this.AverageRate = averageRate;
			this.CurrencyRateDate = currencyRateDate;
			this.CurrencyRateID = currencyRateID;
			this.EndOfDayRate = endOfDayRate;
			this.FromCurrencyCode = fromCurrencyCode;
			this.ModifiedDate = modifiedDate;
			this.ToCurrencyCode = toCurrencyCode;
		}

		[Column("AverageRate")]
		public decimal AverageRate { get; private set; }

		[Column("CurrencyRateDate")]
		public DateTime CurrencyRateDate { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CurrencyRateID")]
		public int CurrencyRateID { get; private set; }

		[Column("EndOfDayRate")]
		public decimal EndOfDayRate { get; private set; }

		[Column("FromCurrencyCode")]
		public string FromCurrencyCode { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("ToCurrencyCode")]
		public string ToCurrencyCode { get; private set; }

		[ForeignKey("FromCurrencyCode")]
		public virtual Currency CurrencyNavigation { get; private set; }

		[ForeignKey("ToCurrencyCode")]
		public virtual Currency Currency1Navigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ca0976087f04f0e5200a24086396930a</Hash>
</Codenesium>*/