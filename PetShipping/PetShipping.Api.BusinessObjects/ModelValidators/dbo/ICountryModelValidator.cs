using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface ICountryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(CountryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, CountryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5103f3a8cfe60596218d714e23004eca</Hash>
</Codenesium>*/