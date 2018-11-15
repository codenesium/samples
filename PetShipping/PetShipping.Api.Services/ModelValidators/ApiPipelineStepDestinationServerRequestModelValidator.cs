using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepDestinationServerRequestModelValidator : AbstractApiPipelineStepDestinationServerRequestModelValidator, IApiPipelineStepDestinationServerRequestModelValidator
	{
		public ApiPipelineStepDestinationServerRequestModelValidator(IPipelineStepDestinationRepository pipelineStepDestinationRepository)
			: base(pipelineStepDestinationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationServerRequestModel model)
		{
			this.DestinationIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationServerRequestModel model)
		{
			this.DestinationIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>52f9bda13a240284b7db8fb8cb561fa0</Hash>
</Codenesium>*/