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
		public int productID {get; set;}
		public DateTime startDate {get; set;}
		public Nullable<DateTime> endDate {get; set;}
		public decimal listPrice {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>d42500440045fee296e24cc0e21d798e</Hash>
</Codenesium>*/