using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d4631d75780788d82cabd9411bb685ca</Hash>
</Codenesium>*/