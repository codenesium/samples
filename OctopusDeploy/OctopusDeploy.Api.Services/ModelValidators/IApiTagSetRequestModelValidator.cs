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
    <Hash>3f3817322d2c62756e6e5407eaa60b51</Hash>
</Codenesium>*/