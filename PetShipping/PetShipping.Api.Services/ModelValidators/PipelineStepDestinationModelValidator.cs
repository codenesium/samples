using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepDestinationRequestModelValidator: AbstractApiPipelineStepDestinationRequestModelValidator, IApiPipelineStepDestinationRequestModelValidator
	{
		public ApiPipelineStepDestinationRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationRequestModel model)
		{
			this.DestinationIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationRequestModel model)
		{
			this.DestinationIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>e533105b8bda05bda60890bb29fe2ecb</Hash>
</Codenesium>*/