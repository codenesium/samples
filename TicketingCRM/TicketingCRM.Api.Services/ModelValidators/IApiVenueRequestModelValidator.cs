using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiVenueRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVenueRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVenueRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>305cb4e707af0579f14e1e41012f6030</Hash>
</Codenesium>*/