using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiClientRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d73d611e41abfa85f4e72af499cd961a</Hash>
</Codenesium>*/