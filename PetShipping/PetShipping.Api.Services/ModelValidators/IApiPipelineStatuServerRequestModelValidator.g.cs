using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStatuServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatuServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatuServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>844bb66a7008d7bdd8c76b624d0e1211</Hash>
</Codenesium>*/