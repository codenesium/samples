using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SalesTaxRateModelValidator: AbstractSalesTaxRateModelValidator,ISalesTaxRateModelValidator
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

		public void PatchMode()
		{
			this.StateProvinceIDRules();
			this.TaxTypeRules();
			this.TaxRateRules();
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>b3653ea36d0cc1e226223edb7ce1cd98</Hash>
</Codenesium>*/