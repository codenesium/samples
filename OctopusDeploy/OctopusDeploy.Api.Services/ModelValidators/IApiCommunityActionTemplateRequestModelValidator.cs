using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiCommunityActionTemplateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCommunityActionTemplateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCommunityActionTemplateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>302b1edc52f2f3287f3157ba6748ffa8</Hash>
</Codenesium>*/