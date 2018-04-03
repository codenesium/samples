using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesPerson", Schema="Sales")]
	public partial class EFSalesPerson
	{
		public EFSalesPerson()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public Nullable<int> territoryID {get; set;}
		public Nullable<decimal> salesQuota {get; set;}
		public decimal bonus {get; set;}
		public decimal commissionPct {get; set;}
		public decimal salesYTD {get; set;}
		public decimal salesLastYear {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>af29a8b91648299fa071e38ecb72b3f2</Hash>
</Codenesium>*/