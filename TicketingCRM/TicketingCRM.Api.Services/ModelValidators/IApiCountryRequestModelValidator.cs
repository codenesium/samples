using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiCountryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>01b23c6232821f888182ba629733c3e9</Hash>
</Codenesium>*/