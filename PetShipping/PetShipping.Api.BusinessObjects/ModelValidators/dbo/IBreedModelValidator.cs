using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBreedModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(BreedModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, BreedModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>00d995896ed909e91a47ea83ab6a1ea4</Hash>
</Codenesium>*/