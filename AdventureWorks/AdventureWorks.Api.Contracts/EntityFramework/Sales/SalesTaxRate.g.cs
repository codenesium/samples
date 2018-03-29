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
		public int SalesTaxRateID {get; set;}
		public int StateProvinceID {get; set;}
		public int TaxType {get; set;}
		public decimal TaxRate {get; set;}
		public string Name {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("StateProvinceID")]
		public virtual EFStateProvince StateProvinceRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>ee384929892c74557f945d2ad31e5f1b</Hash>
</Codenesium>*/