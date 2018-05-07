using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface ICountryRequirementModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(CountryRequirementModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, CountryRequirementModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fb8c38ed803404fd1c8fcbc67418a6dc</Hash>
</Codenesium>*/