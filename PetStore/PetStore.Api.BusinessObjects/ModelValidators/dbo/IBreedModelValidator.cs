using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBreedModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(BreedModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, BreedModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9d19192d196c271d31146bf2a482488c</Hash>
</Codenesium>*/