using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("CurrencyRate", Schema="Sales")]
	public partial class EFCurrencyRate
	{
		public EFCurrencyRate()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CurrencyRateID", TypeName="int")]
		public int CurrencyRateID {get; set;}

		[Column("CurrencyRateDate", TypeName="datetime")]
		public DateTime CurrencyRateDate {get; set;}

		[Column("FromCurrencyCode", TypeName="nchar(3)")]
		public string FromCurrencyCode {get; set;}

		[Column("ToCurrencyCode", TypeName="nchar(3)")]
		public string ToCurrencyCode {get; set;}

		[Column("AverageRate", TypeName="money")]
		public decimal AverageRate {get; set;}

		[Column("EndOfDayRate", TypeName="money")]
		public decimal EndOfDayRate {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("FromCurrencyCode")]
		public virtual EFCurrency Currency { get; set; }
		[ForeignKey("ToCurrencyCode")]
		public virtual EFCurrency Currency1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>ecff3751b5572c3b4a3bdae14b02a507</Hash>
</Codenesium>*/