using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiPaymentTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1d60b27c16185df00ab781477c2df1da</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/