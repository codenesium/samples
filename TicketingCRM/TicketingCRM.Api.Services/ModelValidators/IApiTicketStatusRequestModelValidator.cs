using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8e45b6e57e764fe53a31957e8d0f2151</Hash>
</Codenesium>*/