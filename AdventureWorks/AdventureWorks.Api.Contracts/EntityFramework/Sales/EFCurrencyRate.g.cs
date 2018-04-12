using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
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
			this.FromCurrencyCode = fromCurrencyCode;
			this.ToCurrencyCode = toCurrencyCode;
			this.AverageRate = averageRate;
			this.EndOfDayRate = endOfDayRate;
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
    <Hash>4f97c46ebaa00b4603b68059103acb17</Hash>
</Codenesium>*/