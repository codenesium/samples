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
	public abstract class AbstractApiPipelineStepStatuServerRequestModelValidator : AbstractValidator<ApiPipelineStepStatuServerRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepStatuRepository pipelineStepStatuRepository;

		public AbstractApiPipelineStepStatuServerRequestModelValidator(IPipelineStepStatuRepository pipelineStepStatuRepository)
		{
			this.pipelineStepStatuRepository = pipelineStepStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStatuServerRequestModel model, int id)
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
    <Hash>18e2d00f1847610356c81026304e876f</Hash>
</Codenesium>*/