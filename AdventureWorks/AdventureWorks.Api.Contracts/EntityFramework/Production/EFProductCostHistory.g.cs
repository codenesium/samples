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
		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>36b627e0403e199fcb05059384f91d53</Hash>
</Codenesium>*/