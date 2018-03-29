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
		public int ProductID {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public decimal StandardCost {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>acc63faf5d6c4046196edd0916f7d87e</Hash>
</Codenesium>*/