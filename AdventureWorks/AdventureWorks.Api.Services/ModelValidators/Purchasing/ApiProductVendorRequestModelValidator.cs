using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductVendorRequestModelValidator : AbstractApiProductVendorRequestModelValidator, IApiProductVendorRequestModelValidator
	{
		public ApiProductVendorRequestModelValidator(IProductVendorRepository productVendorRepository)
			: base(productVendorRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductVendorRequestModel model)
		{
			this.AverageLeadTimeRules();
			this.BusinessEntityIDRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MaxOrderQtyRules();
			this.MinOrderQtyRules();
			this.ModifiedDateRules();
			this.OnOrderQtyRules();
			this.StandardPriceRules();
			this.UnitMeasureCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductVendorRequestModel model)
		{
			this.AverageLeadTimeRules();
			this.BusinessEntityIDRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MaxOrderQtyRules();
			this.MinOrderQtyRules();
			this.ModifiedDateRules();
			this.OnOrderQtyRules();
			this.StandardPriceRules();
			this.UnitMeasureCodeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>dba4812f8abad833b6888f843fcfcb62</Hash>
</Codenesium>*/