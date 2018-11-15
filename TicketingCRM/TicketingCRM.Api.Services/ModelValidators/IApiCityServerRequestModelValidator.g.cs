using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiCityServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCityServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCityServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>63a73146f09be873271bfc5570c42f3b</Hash>
</Codenesium>*/