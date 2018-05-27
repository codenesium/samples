using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>6f0f15dc3aadd9d71f9fb6907c41bf1e</Hash>
</Codenesium>*/