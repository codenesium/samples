using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface ISpeciesModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SpeciesModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SpeciesModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5864677b278be04a3e7c606f0524a086</Hash>
</Codenesium>*/