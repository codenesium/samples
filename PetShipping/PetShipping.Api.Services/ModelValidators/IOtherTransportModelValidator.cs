using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiOtherTransportRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9276d69750a3b13b8cbfc03897eeadd8</Hash>
</Codenesium>*/