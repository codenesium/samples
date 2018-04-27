using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class EmployeePayHistoryModelValidator: AbstractEmployeePayHistoryModelValidator, IEmployeePayHistoryModelValidator
	{
		public EmployeePayHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(EmployeePayHistoryModel model)
		{
			this.ModifiedDateRules();
			this.PayFrequencyRules();
			this.RateRules();
			this.RateChangeDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, EmployeePayHistoryModel model)
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
    <Hash>7a59267b38ee807ea6903d17dcc7daeb</Hash>
</Codenesium>*/