using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTransactionStatusServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatusServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatusServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>680eceab4df39d39b4967216e6611db5</Hash>
</Codenesium>*/