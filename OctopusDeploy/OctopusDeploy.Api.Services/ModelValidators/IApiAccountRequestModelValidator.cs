using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiAccountRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAccountRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiAccountRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>102b5cf50774b2c71cf2ceb49a37bed8</Hash>
</Codenesium>*/