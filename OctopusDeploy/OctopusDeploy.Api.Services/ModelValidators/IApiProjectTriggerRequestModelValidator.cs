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
    <Hash>ddee724148567fbb7562e3f88f1703d2</Hash>
</Codenesium>*/