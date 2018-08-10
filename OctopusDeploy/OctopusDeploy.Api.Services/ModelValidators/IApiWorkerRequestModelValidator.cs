using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiWorkerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>c62b70cf86cb1a2a2e9b0239468fabf9</Hash>
</Codenesium>*/