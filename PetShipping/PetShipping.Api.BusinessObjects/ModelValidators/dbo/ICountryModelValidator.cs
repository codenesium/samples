using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiCountryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>85e9084cc64b6918839e37c291cdd1e1</Hash>
</Codenesium>*/