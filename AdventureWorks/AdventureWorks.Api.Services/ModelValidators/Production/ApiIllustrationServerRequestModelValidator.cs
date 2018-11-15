using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiIllustrationServerRequestModelValidator : AbstractApiIllustrationServerRequestModelValidator, IApiIllustrationServerRequestModelValidator
	{
		public ApiIllustrationServerRequestModelValidator(IIllustrationRepository illustrationRepository)
			: base(illustrationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiIllustrationServerRequestModel model)
		{
			this.DiagramRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationServerRequestModel model)
		{
			this.DiagramRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ce090b4f15f4a1746022b39f159cecd2</Hash>
</Codenesium>*/