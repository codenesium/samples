using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiSpeciesModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpeciesModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ad321bb8978dccf59a8bec5403d52fc2</Hash>
</Codenesium>*/