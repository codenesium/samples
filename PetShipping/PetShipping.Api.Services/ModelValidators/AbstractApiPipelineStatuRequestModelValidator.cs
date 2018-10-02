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
	public abstract class AbstractApiPipelineStatuRequestModelValidator : AbstractValidator<ApiPipelineStatuRequestModel>
	{
		private int existingRecordId;

		private IPipelineStatuRepository pipelineStatuRepository;

		public AbstractApiPipelineStatuRequestModelValidator(IPipelineStatuRepository pipelineStatuRepository)
		{
			this.pipelineStatuRepository = pipelineStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStatuRequestModel model, int id)
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
    <Hash>d6b515d70b4ac4f6d40999306be33042</Hash>
</Codenesium>*/