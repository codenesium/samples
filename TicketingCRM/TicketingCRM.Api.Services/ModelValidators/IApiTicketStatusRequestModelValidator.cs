using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiTicketStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>34502a889696588241414153a1d6e3b3</Hash>
</Codenesium>*/