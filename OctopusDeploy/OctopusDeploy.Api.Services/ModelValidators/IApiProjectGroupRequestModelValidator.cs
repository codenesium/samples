using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiProjectGroupRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProjectGroupRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectGroupRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>b0c47b632bd192f4f011612e36ec4ca0</Hash>
</Codenesium>*/