using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductListPriceHistory", Schema="Production")]
	public partial class EFProductListPriceHistory
	{
		public EFProductListPriceHistory()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}
		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate {get; set;}
		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate {get; set;}
		[Column("ListPrice", TypeName="money")]
		public decimal ListPrice {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>6c5a1494367a770ba4d3258d318fdfa5</Hash>
</Codenesium>*/