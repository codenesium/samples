using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesTaxRate", Schema="Sales")]
	public partial class EFSalesTaxRate
	{
		public EFSalesTaxRate()
		{}

		[Key]
		public int salesTaxRateID {get; set;}
		public int stateProvinceID {get; set;}
		public int taxType {get; set;}
		public decimal taxRate {get; set;}
		public string name {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>a7c4124484e3230f87e4c7c4eccabaef</Hash>
</Codenesium>*/