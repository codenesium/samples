using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiSaleTicketsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3f082b4fc8c3cd7bda38bea853a1453f</Hash>
</Codenesium>*/