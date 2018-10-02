using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketStatuRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketStatuRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatuRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>22c6f890ce1864c94e000499a9d940c6</Hash>
</Codenesium>*/