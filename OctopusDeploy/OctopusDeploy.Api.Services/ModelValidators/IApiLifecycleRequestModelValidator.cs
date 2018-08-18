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
    <Hash>8a58f19fe65aed903901915a3a596599</Hash>
</Codenesium>*/