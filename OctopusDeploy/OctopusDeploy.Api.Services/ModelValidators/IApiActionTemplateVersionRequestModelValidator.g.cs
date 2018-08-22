using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiActionTemplateVersionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateVersionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateVersionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>9ed8e63cbf71c58d201bac5d908dd43f</Hash>
</Codenesium>*/