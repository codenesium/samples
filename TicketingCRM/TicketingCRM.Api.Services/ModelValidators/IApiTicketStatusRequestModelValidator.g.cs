using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d7cccf4328c72c6ef7014674dd11c2b3</Hash>
</Codenesium>*/