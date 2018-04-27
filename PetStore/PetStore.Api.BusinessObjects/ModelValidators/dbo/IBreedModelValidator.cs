using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBreedModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(BreedModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, BreedModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2bb217fb6a5d7259c63ec97679fc347b</Hash>
</Codenesium>*/