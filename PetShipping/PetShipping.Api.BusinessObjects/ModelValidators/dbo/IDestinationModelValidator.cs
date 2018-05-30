using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiDestinationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fa2ba7543b558da4efbf7bbe0c15cab4</Hash>
</Codenesium>*/