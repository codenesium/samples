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
		public int productID {get; set;}
		public DateTime startDate {get; set;}
		public Nullable<DateTime> endDate {get; set;}
		public decimal standardCost {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>120e9eb8b6ef53c34b9a807ead6bfc2a</Hash>
</Codenesium>*/