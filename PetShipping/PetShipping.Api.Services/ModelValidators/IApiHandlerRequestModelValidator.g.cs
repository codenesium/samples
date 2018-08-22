using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiHandlerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1a5a752bfe1d1e399c0e20b50841f1e8</Hash>
</Codenesium>*/