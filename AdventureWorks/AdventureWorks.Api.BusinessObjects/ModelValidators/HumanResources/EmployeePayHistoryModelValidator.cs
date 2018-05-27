using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiEmployeePayHistoryRequestModelValidator: AbstractApiEmployeePayHistoryRequestModelValidator, IApiEmployeePayHistoryRequestModelValidator
	{
		public ApiEmployeePayHistoryRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeePayHistoryRequestModel model)
		{
			this.ModifiedDateRules();
			this.PayFrequencyRules();
			this.RateRules();
			this.RateChangeDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeePayHistoryRequestModel model)
		{
			this.ModifiedDateRules();
			this.PayFrequencyRules();
			this.RateRules();
			this.RateChangeDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>db8d3fea3d8e5ea0ba101d869ed4b091</Hash>
</Codenesium>*/