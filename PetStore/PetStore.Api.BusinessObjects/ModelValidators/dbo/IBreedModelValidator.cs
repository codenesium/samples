using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiBreedModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBreedModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>051f6757b1620ab020c2fc6f63c76bc3</Hash>
</Codenesium>*/