using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTransactionStatuServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatuServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatuServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7a4922e05505eac9f097e22f296d5f8f</Hash>
</Codenesium>*/