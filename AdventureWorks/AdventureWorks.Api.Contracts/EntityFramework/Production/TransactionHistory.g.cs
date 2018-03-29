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
		public int TransactionID {get; set;}
		public int ProductID {get; set;}
		public int ReferenceOrderID {get; set;}
		public int ReferenceOrderLineID {get; set;}
		public DateTime TransactionDate {get; set;}
		public string TransactionType {get; set;}
		public int Quantity {get; set;}
		public decimal ActualCost {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>c24e738875aaf648c38a79fba6e5f298</Hash>
</Codenesium>*/