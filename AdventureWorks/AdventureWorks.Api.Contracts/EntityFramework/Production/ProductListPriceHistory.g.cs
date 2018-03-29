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
		public int ProductID {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public decimal ListPrice {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>fdbc3577592772b23409aa88840339e6</Hash>
</Codenesium>*/