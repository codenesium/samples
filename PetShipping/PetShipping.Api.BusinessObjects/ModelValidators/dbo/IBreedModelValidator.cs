using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiBreedModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBreedModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9791f7d1713bc66a4251c2fcc644636b</Hash>
</Codenesium>*/