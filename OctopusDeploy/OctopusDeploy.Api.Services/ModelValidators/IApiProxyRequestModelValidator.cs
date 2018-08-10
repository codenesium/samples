using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiProxyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProxyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiProxyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>7d38df138be8f62d9a49655d306c48ff</Hash>
</Codenesium>*/