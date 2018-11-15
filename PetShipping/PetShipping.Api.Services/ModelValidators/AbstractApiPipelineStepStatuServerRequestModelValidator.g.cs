using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>e7a4b185d2fcdd55c9cfce62e94d9cd1</Hash>
</Codenesium>*/