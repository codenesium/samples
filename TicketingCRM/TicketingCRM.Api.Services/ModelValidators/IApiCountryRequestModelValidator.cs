using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiCountryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dd3e76c97c594ef747018c016007b6ac</Hash>
</Codenesium>*/