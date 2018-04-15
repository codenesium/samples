using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CurrencyRate", Schema="Sales")]
	public partial class EFCurrencyRate
	{
		public EFCurrencyRate()
		{}

		public void SetProperties(
			int currencyRateID,
			DateTime currencyRateDate,
			string fromCurrencyCode,
			string toCurrencyCode,
			decimal averageRate,
			decimal endOfDayRate,
			DateTime modifiedDate)
		{
			this.CurrencyRateID = currencyRateID.ToInt();
			this.CurrencyRateDate = currencyRateDate.ToDateTime();
			this.FromCurrencyCode = fromCurrencyCode.ToString();
			this.ToCurrencyCode = toCurrencyCode.ToString();
			this.AverageRate = averageRate.ToDecimal();
			this.EndOfDayRate = endOfDayRate.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CurrencyRateID", TypeName="int")]
		public int CurrencyRateID { get; set; }

		[Column("CurrencyRateDate", TypeName="datetime")]
		public DateTime CurrencyRateDate { get; set; }

		[Column("FromCurrencyCode", TypeName="nchar(3)")]
		public string FromCurrencyCode { get; set; }

		[Column("ToCurrencyCode", TypeName="nchar(3)")]
		public string ToCurrencyCode { get; set; }

		[Column("AverageRate", TypeName="money")]
		public decimal AverageRate { get; set; }

		[Column("EndOfDayRate", TypeName="money")]
		public decimal EndOfDayRate { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("FromCurrencyCode")]
		public virtual EFCurrency Currency { get; set; }

		[ForeignKey("ToCurrencyCode")]
		public virtual EFCurrency Currency1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>e905a13de38dc30e89d1e358241bcc57</Hash>
</Codenesium>*/