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
    <Hash>cd8f320f87aa8cc5fbbd66ce328df9de</Hash>
</Codenesium>*/