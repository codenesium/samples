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
		public int currencyRateID {get; set;}
		public DateTime currencyRateDate {get; set;}
		public string fromCurrencyCode {get; set;}
		public string toCurrencyCode {get; set;}
		public decimal averageRate {get; set;}
		public decimal endOfDayRate {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>473e87ff99bd747ad6a6631c0e00ca88</Hash>
</Codenesium>*/