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
		public int CurrencyRateID {get; set;}
		public DateTime CurrencyRateDate {get; set;}
		public string FromCurrencyCode {get; set;}
		public string ToCurrencyCode {get; set;}
		public decimal AverageRate {get; set;}
		public decimal EndOfDayRate {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("FromCurrencyCode")]
		public virtual EFCurrency CurrencyRef { get; set; }
		[ForeignKey("ToCurrencyCode")]
		public virtual EFCurrency CurrencyRef1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>0e7242e9340c5466a0360e0134206dec</Hash>
</Codenesium>*/