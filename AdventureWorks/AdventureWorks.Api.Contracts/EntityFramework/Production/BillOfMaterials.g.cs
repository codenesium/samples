using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("BillOfMaterials", Schema="Production")]
	public partial class EFBillOfMaterials
	{
		public EFBillOfMaterials()
		{}

		[Key]
		public int billOfMaterialsID {get; set;}
		public Nullable<int> productAssemblyID {get; set;}
		public int componentID {get; set;}
		public DateTime startDate {get; set;}
		public Nullable<DateTime> endDate {get; set;}
		public string unitMeasureCode {get; set;}
		public short bOMLevel {get; set;}
		public decimal perAssemblyQty {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>5ed72cbf56cb105c18d6d8cf0293ef80</Hash>
</Codenesium>*/