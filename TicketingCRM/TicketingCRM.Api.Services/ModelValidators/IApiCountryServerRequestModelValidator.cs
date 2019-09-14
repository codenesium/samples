using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiCountryServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>601ff2cb3811bda450a004a638ae053d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/