using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiActionTemplateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>881f4d429a6268f0a3bf7c981f1202ab</Hash>
</Codenesium>*/