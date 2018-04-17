using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ShiftModelValidator: AbstractShiftModelValidator, IShiftModelValidator
	{
		public ShiftModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ShiftModel model)
		{
			this.NameRules();
			this.StartTimeRules();
			this.EndTimeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ShiftModel model)
		{
			this.NameRules();
			this.StartTimeRules();
			this.EndTimeRules();
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
    <Hash>396a1af408c776c2e59e01a3e31b7c01</Hash>
</Codenesium>*/