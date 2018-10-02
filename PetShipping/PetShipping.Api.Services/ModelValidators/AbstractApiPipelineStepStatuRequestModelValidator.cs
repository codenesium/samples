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
	public abstract class AbstractApiPipelineStepStatuRequestModelValidator : AbstractValidator<ApiPipelineStepStatuRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepStatuRepository pipelineStepStatuRepository;

		public AbstractApiPipelineStepStatuRequestModelValidator(IPipelineStepStatuRepository pipelineStepStatuRepository)
		{
			this.pipelineStepStatuRepository = pipelineStepStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStatuRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>af3fc4b8f5688c37e2826e40c29174cc</Hash>
</Codenesium>*/