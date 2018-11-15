using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cae23e6969ec9ffd063f455dc6dd203a</Hash>
</Codenesium>*/