using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("CreditCard", Schema="Sales")]
	public partial class EFCreditCard
	{
		public EFCreditCard()
		{}

		[Key]
		public int CreditCardID {get; set;}
		public string CardType {get; set;}
		public string CardNumber {get; set;}
		public int ExpMonth {get; set;}
		public short ExpYear {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>4348e9167eb06875a4d96bf1b44cef08</Hash>
</Codenesium>*/