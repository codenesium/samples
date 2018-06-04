using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiAirlineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirlineRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2229eb008f74a5cbd1ee37e7c239b12a</Hash>
</Codenesium>*/