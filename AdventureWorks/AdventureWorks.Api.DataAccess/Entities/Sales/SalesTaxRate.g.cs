using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesTaxRate", Schema="Sales")]
	public partial class SalesTaxRate : AbstractEntity
	{
		public SalesTaxRate()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int salesTaxRateID,
			int stateProvinceID,
			decimal taxRate,
			int taxType)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesTaxRateID = salesTaxRateID;
			this.StateProvinceID = stateProvinceID;
			this.TaxRate = taxRate;
			this.TaxType = taxType;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Key]
		[Column("SalesTaxRateID")]
		public virtual int SalesTaxRateID { get; private set; }

		[Column("StateProvinceID")]
		public virtual int StateProvinceID { get; private set; }

		[Column("TaxRate")]
		public virtual decimal TaxRate { get; private set; }

		[Column("TaxType")]
		public virtual int TaxType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b41e0dd234000146e779d83a2e283e0a</Hash>
</Codenesium>*/