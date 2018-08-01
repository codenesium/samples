using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiAccountRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAccountRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiAccountRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>353091c36863744493276285200071cc</Hash>
</Codenesium>*/