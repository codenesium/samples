using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiDestinationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2bd215114862e62ac938798703192ce0</Hash>
</Codenesium>*/