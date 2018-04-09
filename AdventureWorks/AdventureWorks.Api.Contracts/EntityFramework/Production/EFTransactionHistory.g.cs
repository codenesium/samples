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

		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>c1c38d45f1c0467b12871d8e62d8e897</Hash>
</Codenesium>*/