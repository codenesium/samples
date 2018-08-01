using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiTicketRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dd3ada0a23c525dd033c4a0e35005b85</Hash>
</Codenesium>*/