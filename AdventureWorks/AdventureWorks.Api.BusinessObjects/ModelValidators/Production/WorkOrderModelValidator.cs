using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiWorkOrderRequestModelValidator: AbstractApiWorkOrderRequestModelValidator, IApiWorkOrderRequestModelValidator
	{
		public ApiWorkOrderRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRequestModel model)
		{
			this.DueDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.ScrappedQtyRules();
			this.ScrapReasonIDRules();
			this.StartDateRules();
			this.StockedQtyRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRequestModel model)
		{
			this.DueDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.ScrappedQtyRules();
			this.ScrapReasonIDRules();
			this.StartDateRules();
			this.StockedQtyRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>f9e9cb042db991cde9ef16bb778c4960</Hash>
</Codenesium>*/