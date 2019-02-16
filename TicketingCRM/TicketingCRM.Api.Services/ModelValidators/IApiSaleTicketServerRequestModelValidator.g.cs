using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiSaleTicketServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0dd7821a3c7216072a923ac6ce1c5fe4</Hash>
</Codenesium>*/