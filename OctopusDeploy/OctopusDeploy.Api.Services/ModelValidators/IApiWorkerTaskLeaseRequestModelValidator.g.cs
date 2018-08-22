using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiWorkerTaskLeaseRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkerTaskLeaseRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerTaskLeaseRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>41ded5b612fd2fe2e666266e6667022a</Hash>
</Codenesium>*/