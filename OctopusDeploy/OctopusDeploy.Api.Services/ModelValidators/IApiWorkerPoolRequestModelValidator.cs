using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiWorkerPoolRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkerPoolRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerPoolRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>ca45eb5474feefaa913e1bd9dd15a450</Hash>
</Codenesium>*/