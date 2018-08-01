using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiActionTemplateVersionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateVersionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateVersionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>8b083e26b9421f0ff9ca68f280a7765b</Hash>
</Codenesium>*/