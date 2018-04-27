using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CurrencyRate", Schema="Sales")]
	public partial class EFCurrencyRate: AbstractEntityFrameworkPOCO
	{
		public EFCurrencyRate()
		{}

		public void SetProperties(
			int currencyRateID,
			decimal averageRate,
			DateTime currencyRateDate,
			decimal endOfDayRate,
			string fromCurrencyCode,
			DateTime modifiedDate,
			string toCurrencyCode)
		{
			this.AverageRate = averageRate.ToDecimal();
			this.CurrencyRateDate = currencyRateDate.ToDateTime();
			this.CurrencyRateID = currencyRateID.ToInt();
			this.EndOfDayRate = endOfDayRate.ToDecimal();
			this.FromCurrencyCode = fromCurrencyCode.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ToCurrencyCode = toCurrencyCode.ToString();
		}

		[Column("AverageRate", TypeName="money")]
		public decimal AverageRate { get; set; }

		[Column("CurrencyRateDate", TypeName="datetime")]
		public DateTime CurrencyRateDate { get; set; }

		[Key]
		[Column("CurrencyRateID", TypeName="int")]
		public int CurrencyRateID { get; set; }

		[Column("EndOfDayRate", TypeName="money")]
		public decimal EndOfDayRate { get; set; }

		[Column("FromCurrencyCode", TypeName="nchar(3)")]
		public string FromCurrencyCode { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("ToCurrencyCode", TypeName="nchar(3)")]
		public string ToCurrencyCode { get; set; }

		[ForeignKey("FromCurrencyCode")]
		public virtual EFCurrency Currency { get; set; }

		[ForeignKey("ToCurrencyCode")]
		public virtual EFCurrency Currency1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>ec25a62fe1c6f9d2f8dae794d24efe3c</Hash>
</Codenesium>*/