using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiCustomerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5b2cd69a91e6b8bcf874436f6509f16e</Hash>
</Codenesium>*/