using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a2a92393eae4bbcfd485ebcf6fd7bdc6</Hash>
</Codenesium>*/