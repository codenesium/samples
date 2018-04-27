using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface ISpeciesModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SpeciesModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SpeciesModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>28a8b114428a4dbc580e2fc9aa09e2a9</Hash>
</Codenesium>*/