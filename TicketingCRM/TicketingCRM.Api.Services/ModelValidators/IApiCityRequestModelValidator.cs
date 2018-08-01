using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiCityRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCityRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCityRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e3b4e136084ac9335b80bd9dcff63f77</Hash>
</Codenesium>*/