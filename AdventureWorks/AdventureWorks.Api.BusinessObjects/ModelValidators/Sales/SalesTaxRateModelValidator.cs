using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSalesTaxRateModelValidator: AbstractApiSalesTaxRateModelValidator, IApiSalesTaxRateModelValidator
	{
		public ApiSalesTaxRateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTaxRateModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.StateProvinceIDRules();
			this.TaxRateRules();
			this.TaxTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTaxRateModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.StateProvinceIDRules();
			this.TaxRateRules();
			this.TaxTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>f598c1b6396a1bc5474c8087b1571b53</Hash>
</Codenesium>*/