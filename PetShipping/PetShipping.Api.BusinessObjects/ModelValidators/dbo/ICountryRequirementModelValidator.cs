using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface ICountryRequirementModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(CountryRequirementModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, CountryRequirementModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a4f00d6fb8bb688f46a7a648f578c427</Hash>
</Codenesium>*/