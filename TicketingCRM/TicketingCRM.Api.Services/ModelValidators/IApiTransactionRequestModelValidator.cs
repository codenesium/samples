using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTransactionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cfbfaf70be71312f934f5bdd0d4fbc38</Hash>
</Codenesium>*/