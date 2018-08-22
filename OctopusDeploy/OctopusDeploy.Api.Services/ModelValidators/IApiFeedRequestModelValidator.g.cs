using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiFeedRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFeedRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiFeedRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>7675cca482045d53d91153ecfc116ab1</Hash>
</Codenesium>*/