using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSalesTaxRate: AbstractDTO
	{
		public DTOSalesTaxRate() : base()
		{}

		public void SetProperties(int salesTaxRateID,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid,
		                          int stateProvinceID,
		                          decimal taxRate,
		                          int taxType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.SalesTaxRateID = salesTaxRateID.ToInt();
			this.StateProvinceID = stateProvinceID.ToInt();
			this.TaxRate = taxRate.ToDecimal();
			this.TaxType = taxType.ToInt();
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public int SalesTaxRateID { get; set; }
		public int StateProvinceID { get; set; }
		public decimal TaxRate { get; set; }
		public int TaxType { get; set; }
	}
}

/*<Codenesium>
    <Hash>fdea0a25990aff0f00c77c551e5d05b5</Hash>
</Codenesium>*/