using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiUserRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>e9d347d75535dab4a5d1121b600a4d50</Hash>
</Codenesium>*/