using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiWorkerPoolRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkerPoolRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerPoolRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>3d377e43563e45cbb11dd96de7f941b2</Hash>
</Codenesium>*/