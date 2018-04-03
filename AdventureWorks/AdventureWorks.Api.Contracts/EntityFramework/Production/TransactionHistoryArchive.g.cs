using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("TransactionHistoryArchive", Schema="Production")]
	public partial class EFTransactionHistoryArchive
	{
		public EFTransactionHistoryArchive()
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
    <Hash>bd2af2bf1ed936a5450143f6f613949b</Hash>
</Codenesium>*/