using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiWorkerTaskLeaseRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkerTaskLeaseRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerTaskLeaseRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>64cd50252cc696cc189dc6642baa2973</Hash>
</Codenesium>*/