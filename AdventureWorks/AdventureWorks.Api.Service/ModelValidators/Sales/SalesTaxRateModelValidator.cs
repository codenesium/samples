using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SalesTaxRateModelValidator: AbstractSalesTaxRateModelValidator, ISalesTaxRateModelValidator
	{
		public SalesTaxRateModelValidator()
		{   }

		public void CreateMode()
		{
			this.StateProvinceIDRules();
			this.TaxTypeRules();
			this.TaxRateRules();
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.StateProvinceIDRules();
			this.TaxTypeRules();
			this.TaxRateRules();
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>e424caefdf8d2c2b987cef8a9e2041ec</Hash>
</Codenesium>*/