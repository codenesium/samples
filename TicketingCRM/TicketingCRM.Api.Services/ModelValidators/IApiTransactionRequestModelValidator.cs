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
    <Hash>6c69c09f10b923c1408a98df1232abe2</Hash>
</Codenesium>*/