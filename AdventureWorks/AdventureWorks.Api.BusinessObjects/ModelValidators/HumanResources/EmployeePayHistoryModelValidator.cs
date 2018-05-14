using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiEmployeePayHistoryModelValidator: AbstractApiEmployeePayHistoryModelValidator, IApiEmployeePayHistoryModelValidator
	{
		public ApiEmployeePayHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeePayHistoryModel model)
		{
			this.ModifiedDateRules();
			this.PayFrequencyRules();
			this.RateRules();
			this.RateChangeDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeePayHistoryModel model)
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
    <Hash>4e004c61d598a4ceaa2f9e2266afe5df</Hash>
</Codenesium>*/