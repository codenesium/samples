using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiPipelineStepDestinationModelValidator: AbstractApiPipelineStepDestinationModelValidator, IApiPipelineStepDestinationModelValidator
	{
		public ApiPipelineStepDestinationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationModel model)
		{
			this.DestinationIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationModel model)
		{
			this.DestinationIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4e0e08e9eb9df74be13016ac06b3b5a6</Hash>
</Codenesium>*/