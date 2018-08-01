using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiCustomerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8fcbcbaf521878af55e42e12d548fa2f</Hash>
</Codenesium>*/