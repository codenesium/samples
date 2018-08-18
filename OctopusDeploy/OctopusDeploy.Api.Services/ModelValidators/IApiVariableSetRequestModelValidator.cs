using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiVariableSetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVariableSetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiVariableSetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>446cb0e4ec599d84f185e08343de1582</Hash>
</Codenesium>*/