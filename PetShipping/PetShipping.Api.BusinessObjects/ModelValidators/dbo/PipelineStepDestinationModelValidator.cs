using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class PipelineStepDestinationModelValidator: AbstractPipelineStepDestinationModelValidator, IPipelineStepDestinationModelValidator
	{
		public PipelineStepDestinationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PipelineStepDestinationModel model)
		{
			this.DestinationIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStepDestinationModel model)
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
    <Hash>bd7ca0d95c184066b584785dd22a161e</Hash>
</Codenesium>*/