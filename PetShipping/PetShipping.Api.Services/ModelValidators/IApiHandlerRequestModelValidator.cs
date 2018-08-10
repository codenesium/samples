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
    <Hash>9794248c3db04a972c1835ba79e80439</Hash>
</Codenesium>*/