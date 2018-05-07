using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface ISpeciesModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SpeciesModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SpeciesModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>08f09d768e44dc9b7f3b5ae56de5f656</Hash>
</Codenesium>*/