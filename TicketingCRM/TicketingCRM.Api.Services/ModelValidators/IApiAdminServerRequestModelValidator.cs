using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiAdminServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAdminServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a860abb0f34642d16673e53e92cc03b9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/