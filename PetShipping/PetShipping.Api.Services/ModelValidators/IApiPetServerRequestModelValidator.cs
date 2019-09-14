using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPetServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPetServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>da172ba30e7e10a88ee291c351f55019</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/