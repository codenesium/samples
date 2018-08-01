using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiTransactionStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>aae9a720c39e20b1890ba409ec7f5945</Hash>
</Codenesium>*/