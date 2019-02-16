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
			int salesTaxRateID,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int stateProvinceID,
			decimal taxRate,
			int taxType)
		{
			this.SalesTaxRateID = salesTaxRateID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
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
    <Hash>7bb9839150eae9d131fc3a49ab9b0845</Hash>
</Codenesium>*/