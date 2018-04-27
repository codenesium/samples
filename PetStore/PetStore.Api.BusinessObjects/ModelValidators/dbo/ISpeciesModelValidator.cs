using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface ISpeciesModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SpeciesModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SpeciesModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>56a63f5fca11a1787e5d78d644397d8b</Hash>
</Codenesium>*/