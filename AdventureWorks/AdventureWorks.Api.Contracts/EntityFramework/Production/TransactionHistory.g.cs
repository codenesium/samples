using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("TransactionHistory", Schema="Production")]
	public partial class EFTransactionHistory
	{
		public EFTransactionHistory()
		{}

		[Key]
		public int transactionID {get; set;}
		public int productID {get; set;}
		public int referenceOrderID {get; set;}
		public int referenceOrderLineID {get; set;}
		public DateTime transactionDate {get; set;}
		public string transactionType {get; set;}
		public int quantity {get; set;}
		public decimal actualCost {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>0f2896ce7affddcaab39e82ce785284b</Hash>
</Codenesium>*/