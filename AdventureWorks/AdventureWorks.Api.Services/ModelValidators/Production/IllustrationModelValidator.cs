using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiIllustrationRequestModelValidator: AbstractApiIllustrationRequestModelValidator, IApiIllustrationRequestModelValidator
	{
		public ApiIllustrationRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiIllustrationRequestModel model)
		{
			this.DiagramRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationRequestModel model)
		{
			this.DiagramRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>8befc732ba83db5b9a7da986ed7e1000</Hash>
</Codenesium>*/