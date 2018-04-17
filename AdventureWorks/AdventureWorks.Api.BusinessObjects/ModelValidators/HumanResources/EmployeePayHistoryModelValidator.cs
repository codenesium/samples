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
			this.RateChangeDateRules();
			this.RateRules();
			this.PayFrequencyRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, EmployeePayHistoryModel model)
		{
			this.RateChangeDateRules();
			this.RateRules();
			this.PayFrequencyRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>58e22120e745683838e22127bc813cbc</Hash>
</Codenesium>*/