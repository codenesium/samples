using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepStatusServerRequestModelValidator : AbstractValidator<ApiPipelineStepStatusServerRequestModel>
	{
		private int existingRecordId;

		protected IPipelineStepStatusRepository PipelineStepStatusRepository { get; private set; }

		public AbstractApiPipelineStepStatusServerRequestModelValidator(IPipelineStepStatusRepository pipelineStepStatusRepository)
		{
			this.PipelineStepStatusRepository = pipelineStepStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStatusServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>5e0e32dc93662a2bb6e1f24a0e15796c</Hash>
</Codenesium>*/