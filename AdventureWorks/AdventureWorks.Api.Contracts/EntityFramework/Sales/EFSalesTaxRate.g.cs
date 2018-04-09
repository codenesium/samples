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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SalesTaxRateID", TypeName="int")]
		public int SalesTaxRateID {get; set;}

		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID {get; set;}

		[Column("TaxType", TypeName="tinyint")]
		public int TaxType {get; set;}

		[Column("TaxRate", TypeName="smallmoney")]
		public decimal TaxRate {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFStateProvince StateProvince { get; set; }
	}
}

/*<Codenesium>
    <Hash>8a39b94f127b28c365a63c4fdd29f17c</Hash>
</Codenesium>*/