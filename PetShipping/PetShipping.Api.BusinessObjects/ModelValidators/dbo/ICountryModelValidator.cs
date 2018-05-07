using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface ICountryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(CountryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, CountryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>35642c96817f6127936b27346b98ceee</Hash>
</Codenesium>*/