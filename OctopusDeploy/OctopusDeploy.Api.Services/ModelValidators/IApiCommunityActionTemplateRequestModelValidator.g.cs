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
    <Hash>53e796ae2f714ffb552fb479b43f1a0f</Hash>
</Codenesium>*/