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
		public int creditCardID {get; set;}
		public string cardType {get; set;}
		public string cardNumber {get; set;}
		public int expMonth {get; set;}
		public short expYear {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>0b6acb139cf7613558d68bfcacf6fbef</Hash>
</Codenesium>*/