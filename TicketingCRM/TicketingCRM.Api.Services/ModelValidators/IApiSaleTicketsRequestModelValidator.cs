using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiSaleTicketsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f57975da09116e8e8d781f4b83f1ec25</Hash>
</Codenesium>*/