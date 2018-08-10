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
    <Hash>a23207676cb846d3bd1fd270f8db8a63</Hash>
</Codenesium>*/