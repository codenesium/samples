using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PersonCreditCard", Schema="Sales")]
	public partial class EFPersonCreditCard
	{
		public EFPersonCreditCard()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public int creditCardID {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>baf860d159e20c3393d6639211e951b1</Hash>
</Codenesium>*/