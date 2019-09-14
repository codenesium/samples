using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepDestinationServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9892f24df7112d0e2c7308e12d863334</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/