using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSalesTaxRateRequestModelValidator: AbstractApiSalesTaxRateRequestModelValidator, IApiSalesTaxRateRequestModelValidator
	{
		public ApiSalesTaxRateRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTaxRateRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.StateProvinceIDRules();
			this.TaxRateRules();
			this.TaxTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTaxRateRequestModel model)
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
    <Hash>de4bb39abdb500a21a871b2341746ac1</Hash>
</Codenesium>*/