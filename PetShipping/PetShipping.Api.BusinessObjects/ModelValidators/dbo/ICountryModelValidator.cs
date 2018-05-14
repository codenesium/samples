using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiCountryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9dfe5f2ad9ef12adcfe3ecd264cef1cc</Hash>
</Codenesium>*/