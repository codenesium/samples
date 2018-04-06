using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductCostHistory", Schema="Production")]
	public partial class EFProductCostHistory
	{
		public EFProductCostHistory()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}
		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate {get; set;}
		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate {get; set;}
		[Column("StandardCost", TypeName="money")]
		public decimal StandardCost {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>94b87602007984fe18fc3021d2e18363</Hash>
</Codenesium>*/