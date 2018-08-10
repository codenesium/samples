using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiSpeciesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>343c5741feb86dfef4cb081afe93f21d</Hash>
</Codenesium>*/