using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiSpeciesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpeciesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>99b06adc4a584746b8a16411abc28ba3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/