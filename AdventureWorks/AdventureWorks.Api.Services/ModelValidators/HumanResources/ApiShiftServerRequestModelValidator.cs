using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiShiftServerRequestModelValidator : AbstractApiShiftServerRequestModelValidator, IApiShiftServerRequestModelValidator
	{
		public ApiShiftServerRequestModelValidator(IShiftRepository shiftRepository)
			: base(shiftRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiShiftServerRequestModel model)
		{
			this.EndTimeRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.StartTimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftServerRequestModel model)
		{
			this.EndTimeRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.StartTimeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>dfb629956d0631913f08c64e48bb23f0</Hash>
</Codenesium>*/