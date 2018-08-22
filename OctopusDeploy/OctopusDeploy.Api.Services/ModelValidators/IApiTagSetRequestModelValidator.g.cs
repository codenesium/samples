using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiTagSetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTagSetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiTagSetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>0d7c879069c11a06b652227217e532d3</Hash>
</Codenesium>*/