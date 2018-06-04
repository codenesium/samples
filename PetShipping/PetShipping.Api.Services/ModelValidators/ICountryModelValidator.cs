using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiCountryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7bbf1033bb1bf0028015991746909bee</Hash>
</Codenesium>*/