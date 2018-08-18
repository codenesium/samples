using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiCityRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCityRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCityRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>10a7a56b41490ce999591ffb9e12255a</Hash>
</Codenesium>*/