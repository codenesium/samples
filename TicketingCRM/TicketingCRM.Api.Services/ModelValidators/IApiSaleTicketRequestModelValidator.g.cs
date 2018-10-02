using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiSaleTicketRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>83930bbaafc9606970936875cfcd930d</Hash>
</Codenesium>*/