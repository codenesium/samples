using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiEmployeeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>be8c07604ba74093a932d8b6c3314b02</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/