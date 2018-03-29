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
		public int TransactionID {get; set;}
		public int ProductID {get; set;}
		public int ReferenceOrderID {get; set;}
		public int ReferenceOrderLineID {get; set;}
		public DateTime TransactionDate {get; set;}
		public string TransactionType {get; set;}
		public int Quantity {get; set;}
		public decimal ActualCost {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>a6cc79e5fa44aa98786cd49d04761cf5</Hash>
</Codenesium>*/