using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiIllustrationRequestModelValidator : AbstractApiIllustrationRequestModelValidator, IApiIllustrationRequestModelValidator
	{
		public ApiIllustrationRequestModelValidator(IIllustrationRepository illustrationRepository)
			: base(illustrationRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>313bb69c13f9d3e700c4156686e22210</Hash>
</Codenesium>*/