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
    <Hash>754ea1fd4b4a7a6df1458816196ac0e5</Hash>
</Codenesium>*/