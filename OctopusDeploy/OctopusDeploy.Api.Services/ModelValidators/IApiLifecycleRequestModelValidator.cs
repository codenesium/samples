using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiLifecycleRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLifecycleRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiLifecycleRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>fe775feb690bc6e64ad19b915d02a065</Hash>
</Codenesium>*/