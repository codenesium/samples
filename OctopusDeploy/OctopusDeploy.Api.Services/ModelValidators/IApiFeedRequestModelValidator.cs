using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiFeedRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFeedRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiFeedRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>531706b7916ba1dcc306afac0eb64abb</Hash>
</Codenesium>*/