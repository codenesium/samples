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
			this.RuleFor(x => x.PipelineStatusId).MustAsync(this.BeValidPipelineStatus).When(x => x?.PipelineStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void SaleIdRules()
		{
		}

		private async Task<bool> BeValidPipelineStatus(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineRepository.GetPipelineStatus(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f5ffd76151998a6b50e9c9ea5f582529</Hash>
</Codenesium>*/