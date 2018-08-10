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
    <Hash>182f980c49c526296058158e3cdf3589</Hash>
</Codenesium>*/