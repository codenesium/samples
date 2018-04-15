using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesTaxRate", Schema="Sales")]
	public partial class EFSalesTaxRate
	{
		public EFSalesTaxRate()
		{}

		public void SetProperties(
			int salesTaxRateID,
			int stateProvinceID,
			int taxType,
			decimal taxRate,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.SalesTaxRateID = salesTaxRateID.ToInt();
			this.StateProvinceID = stateProvinceID.ToInt();
			this.TaxType = taxType.ToInt();
			this.TaxRate = taxRate.ToDecimal();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SalesTaxRateID", TypeName="int")]
		public int SalesTaxRateID { get; set; }

		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID { get; set; }

		[Column("TaxType", TypeName="tinyint")]
		public int TaxType { get; set; }

		[Column("TaxRate", TypeName="smallmoney")]
		public decimal TaxRate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("StateProvinceID")]
		public virtual EFStateProvince StateProvince { get; set; }
	}
}

/*<Codenesium>
    <Hash>fa363768f3dbe5199fc7928dc2ac93a8</Hash>
</Codenesium>*/