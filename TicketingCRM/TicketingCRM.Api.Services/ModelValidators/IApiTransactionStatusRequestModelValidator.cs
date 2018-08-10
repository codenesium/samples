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
    <Hash>1a7f839ac13f4c625bb401fe4a966070</Hash>
</Codenesium>*/