using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiShiftRequestModelValidator: AbstractApiShiftRequestModelValidator, IApiShiftRequestModelValidator
	{
		public ApiShiftRequestModelValidator()
		{   }

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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>337dd9e2d690f1c42fc6ffd5b549ddd5</Hash>
</Codenesium>*/