using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTransactionStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>faa5f30e6f26544b44a61e38d761c01c</Hash>
</Codenesium>*/