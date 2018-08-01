using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiTagSetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTagSetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiTagSetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>5e4cbffcacd963a5001205f8490bcedd</Hash>
</Codenesium>*/