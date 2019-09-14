using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTicketStatusServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTicketStatusServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatusServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>30d6f0090af20a2e9f670a4da5a48428</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/