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
			this.EndTimeRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.StartTimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ShiftModel model)
		{
			this.EndTimeRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.StartTimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>39269b846e959eae2764d03053221a2f</Hash>
</Codenesium>*/