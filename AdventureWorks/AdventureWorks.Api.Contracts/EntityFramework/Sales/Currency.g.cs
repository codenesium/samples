using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Currency", Schema="Sales")]
	public partial class EFCurrency
	{
		public EFCurrency()
		{}

		[Key]
		public string CurrencyCode {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>8302e6d4325c10f7b3e49695ea010811</Hash>
</Codenesium>*/