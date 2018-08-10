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
    <Hash>628ed2ccabc5eeb49ff559bffaaf4389</Hash>
</Codenesium>*/