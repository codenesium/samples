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
    <Hash>ca4aaecd98273c9f31b8758ec6968d33</Hash>
</Codenesium>*/