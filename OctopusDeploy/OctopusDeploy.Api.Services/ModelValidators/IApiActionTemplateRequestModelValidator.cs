using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiActionTemplateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>6e6b8f42c0e838595d0590e82184de30</Hash>
</Codenesium>*/