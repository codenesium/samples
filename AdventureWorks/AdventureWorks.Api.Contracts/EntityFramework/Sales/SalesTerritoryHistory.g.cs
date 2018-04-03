using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesTerritoryHistory", Schema="Sales")]
	public partial class EFSalesTerritoryHistory
	{
		public EFSalesTerritoryHistory()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public int territoryID {get; set;}
		public DateTime startDate {get; set;}
		public Nullable<DateTime> endDate {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>3ef5fb00242121845b6fe18ccfbcaacc</Hash>
</Codenesium>*/