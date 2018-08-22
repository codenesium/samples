using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>351f95fffd8e33f139174b6eeade2fae</Hash>
</Codenesium>*/