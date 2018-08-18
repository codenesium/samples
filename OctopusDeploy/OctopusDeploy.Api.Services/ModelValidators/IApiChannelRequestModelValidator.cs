using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiChannelRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChannelRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiChannelRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>b2e754c303f9ca580c9444ba10aed9c2</Hash>
</Codenesium>*/