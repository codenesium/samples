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
    <Hash>a37d5a3ed84603511dd035b0a3471a18</Hash>
</Codenesium>*/