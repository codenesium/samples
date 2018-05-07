using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBreedModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(BreedModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, BreedModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d1d723aaae26e0af74d8597770a02bec</Hash>
</Codenesium>*/