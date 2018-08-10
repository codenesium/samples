using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>eb2f6e9cbb12d2091aef6c2e6c67508d</Hash>
</Codenesium>*/