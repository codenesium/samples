using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesTerritory", Schema="Sales")]
	public partial class EFSalesTerritory
	{
		public EFSalesTerritory()
		{}

		[Key]
		public int territoryID {get; set;}
		public string name {get; set;}
		public string countryRegionCode {get; set;}
		public string @group {get; set;}
		public decimal salesYTD {get; set;}
		public decimal salesLastYear {get; set;}
		public decimal costYTD {get; set;}
		public decimal costLastYear {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>6c24d12ce6ed7348615f4a0dd859c52a</Hash>
</Codenesium>*/