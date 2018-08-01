using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiProxyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProxyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiProxyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>9df1dd8a2ef1b0dc87bb1cea07bc395e</Hash>
</Codenesium>*/