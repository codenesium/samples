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
    <Hash>f467e82a2d47d558160e282031179f9e</Hash>
</Codenesium>*/