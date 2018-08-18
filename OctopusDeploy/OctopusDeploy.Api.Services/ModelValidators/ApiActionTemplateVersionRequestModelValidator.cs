using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiActionTemplateVersionRequestModelValidator : AbstractApiActionTemplateVersionRequestModelValidator, IApiActionTemplateVersionRequestModelValidator
	{
		public ApiActionTemplateVersionRequestModelValidator(IActionTemplateVersionRepository actionTemplateVersionRepository)
			: base(actionTemplateVersionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateVersionRequestModel model)
		{
			this.ActionTypeRules();
			this.JSONRules();
			this.LatestActionTemplateIdRules();
			this.NameRules();
			this.VersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateVersionRequestModel model)
		{
			this.ActionTypeRules();
			this.JSONRules();
			this.LatestActionTemplateIdRules();
			this.NameRules();
			this.VersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>5543f039bac5e8f7bedd7a536b6bb69a</Hash>
</Codenesium>*/