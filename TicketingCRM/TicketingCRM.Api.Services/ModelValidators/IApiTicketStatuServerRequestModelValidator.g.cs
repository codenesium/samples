using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketStatuServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketStatuServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatuServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>148d3649f8bf47bae4b6098c920b44f6</Hash>
</Codenesium>*/