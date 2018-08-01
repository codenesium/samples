using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiWorkerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>9f03254023017199b500b34c3d1ad8ff</Hash>
</Codenesium>*/