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
		public string currencyCode {get; set;}
		public string name {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>7d4a4cafcc0971d82f765915b16eac5d</Hash>
</Codenesium>*/