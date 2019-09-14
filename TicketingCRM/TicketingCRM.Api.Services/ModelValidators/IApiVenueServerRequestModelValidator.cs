using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiVenueServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVenueServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVenueServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>589cafee80d05dff19505a5cb588bf74</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/