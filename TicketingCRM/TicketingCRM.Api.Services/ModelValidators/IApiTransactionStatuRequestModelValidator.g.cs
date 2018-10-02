using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTransactionStatuRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatuRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatuRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>650cb83cdfe5c05c2831aeec913b9f51</Hash>
</Codenesium>*/