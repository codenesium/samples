using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiWorkOrderRoutingRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRoutingRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fe9b32f44b1c25683c124c0a9ef9d4c3</Hash>
</Codenesium>*/