using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiHandlerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>476cc1332f9edce2e47988d0a13fe3bf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/