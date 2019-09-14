using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiSaleTicketsServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketsServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketsServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dd7c8f3e0502e38decdb42d72ab696a0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/