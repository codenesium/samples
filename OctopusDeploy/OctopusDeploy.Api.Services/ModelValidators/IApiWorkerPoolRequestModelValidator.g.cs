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
    <Hash>e1858ca84558c88e56ffecc22221ba21</Hash>
</Codenesium>*/