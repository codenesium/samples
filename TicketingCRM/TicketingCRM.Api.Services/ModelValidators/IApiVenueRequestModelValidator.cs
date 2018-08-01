using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiVenueRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVenueRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVenueRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8139bc884d16c8b6c31b3f620d597b8a</Hash>
</Codenesium>*/