using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiTransactionServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0c56b4e0dd3f8cc8235bfdb9fe3a4bed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/