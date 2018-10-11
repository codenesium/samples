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
	public abstract class AbstractApiPipelineRequestModelValidator : AbstractValidator<ApiPipelineRequestModel>
	{
		private int existingRecordId;

		private IPipelineRepository pipelineRepository;

		public AbstractApiPipelineRequestModelValidator(IPipelineRepository pipelineRepository)
		{
			this.pipelineRepository = pipelineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PipelineStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStatusId).MustAsync(this.BeValidPipelineStatuByPipelineStatusId).When(x => x?.PipelineStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void SaleIdRules()
		{
		}

		private async Task<bool> BeValidPipelineStatuByPipelineStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineRepository.PipelineStatuByPipelineStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>1c76ec9e978cb6d4f4657c09d3fe8d23</Hash>
</Codenesium>*/