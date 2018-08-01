using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiOctopusServerNodeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOctopusServerNodeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiOctopusServerNodeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>4ee1ad8c1585c007f83a5640eb8ae4a3</Hash>
</Codenesium>*/