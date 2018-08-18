using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiEmployeePayHistoryRequestModelValidator : AbstractApiEmployeePayHistoryRequestModelValidator, IApiEmployeePayHistoryRequestModelValidator
	{
		public ApiEmployeePayHistoryRequestModelValidator(IEmployeePayHistoryRepository employeePayHistoryRepository)
			: base(employeePayHistoryRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>e278a2dd1b25948f9228d9626f3c1a9b</Hash>
</Codenesium>*/