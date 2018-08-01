using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiShiftRequestModelValidator : AbstractApiShiftRequestModelValidator, IApiShiftRequestModelValidator
	{
		public ApiShiftRequestModelValidator(IShiftRepository shiftRepository)
			: base(shiftRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiShiftRequestModel model)
		{
			this.EndTimeRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.StartTimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftRequestModel model)
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
    <Hash>76d8af4a24211d86f952548cabec31e1</Hash>
</Codenesium>*/