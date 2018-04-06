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
		public virtual EFCurrency CurrencyRef { get; set; }
		[ForeignKey("ToCurrencyCode")]
		public virtual EFCurrency CurrencyRef1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>dfcb0f5088caa31f4bd008ad4cfa77b0</Hash>
</Codenesium>*/