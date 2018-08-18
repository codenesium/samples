using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiProjectTriggerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProjectTriggerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectTriggerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>6c19e47f672772fc8e37f4527f3317fa</Hash>
</Codenesium>*/