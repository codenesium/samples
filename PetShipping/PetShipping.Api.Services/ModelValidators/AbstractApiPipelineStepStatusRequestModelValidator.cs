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
	public abstract class AbstractApiPipelineStepStatusRequestModelValidator : AbstractValidator<ApiPipelineStepStatusRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepStatusRepository pipelineStepStatusRepository;

		public AbstractApiPipelineStepStatusRequestModelValidator(IPipelineStepStatusRepository pipelineStepStatusRepository)
		{
			this.pipelineStepStatusRepository = pipelineStepStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStatusRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>b3448b0b5bb3424f8b05a275c46e85c3</Hash>
</Codenesium>*/