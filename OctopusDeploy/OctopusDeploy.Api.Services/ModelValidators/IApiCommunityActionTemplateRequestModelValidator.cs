using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiCommunityActionTemplateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCommunityActionTemplateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCommunityActionTemplateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>343dffbf8676064ca16a89ab39d223e1</Hash>
</Codenesium>*/