using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiClientServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3f131f34ffa465035020f8b5040d28f8</Hash>
</Codenesium>*/