using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiWorkOrderRoutingRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRoutingRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>04a1c4603bc79c099eb51308f6f26980</Hash>
</Codenesium>*/