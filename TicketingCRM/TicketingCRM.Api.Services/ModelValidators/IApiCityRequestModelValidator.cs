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
    <Hash>ca499eceb4d16152ec40b55e38a3c537</Hash>
</Codenesium>*/