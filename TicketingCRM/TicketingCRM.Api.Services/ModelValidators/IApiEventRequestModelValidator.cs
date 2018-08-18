using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiEventRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6ff29bf4b69c95297788e2f536d3e08c</Hash>
</Codenesium>*/