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
    <Hash>2a291cfc6be9af0c1fa3b5ad0dead43b</Hash>
</Codenesium>*/