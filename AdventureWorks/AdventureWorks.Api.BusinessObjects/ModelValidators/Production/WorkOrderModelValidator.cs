using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiWorkOrderModelValidator: AbstractApiWorkOrderModelValidator, IApiWorkOrderModelValidator
	{
		public ApiWorkOrderModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderModel model)
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
    <Hash>c7c475595e6d0a120aa096a4cbb98df3</Hash>
</Codenesium>*/