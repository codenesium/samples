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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("TransactionID", TypeName="int")]
		public int TransactionID {get; set;}
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}
		[Column("ReferenceOrderID", TypeName="int")]
		public int ReferenceOrderID {get; set;}
		[Column("ReferenceOrderLineID", TypeName="int")]
		public int ReferenceOrderLineID {get; set;}
		[Column("TransactionDate", TypeName="datetime")]
		public DateTime TransactionDate {get; set;}
		[Column("TransactionType", TypeName="nchar(1)")]
		public string TransactionType {get; set;}
		[Column("Quantity", TypeName="int")]
		public int Quantity {get; set;}
		[Column("ActualCost", TypeName="money")]
		public decimal ActualCost {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>7a4c98ff68a5c127154e8c7ff6b67863</Hash>
</Codenesium>*/