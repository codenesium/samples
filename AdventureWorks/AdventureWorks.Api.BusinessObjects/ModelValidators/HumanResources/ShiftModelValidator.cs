using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiShiftModelValidator: AbstractApiShiftModelValidator, IApiShiftModelValidator
	{
		public ApiShiftModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiShiftModel model)
		{
			this.EndTimeRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.StartTimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftModel model)
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
    <Hash>65db3c15a82d5b4df706a1859bce6a37</Hash>
</Codenesium>*/