using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiTransactionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e38de9dee546cbd8cf708342e1d285bf</Hash>
</Codenesium>*/