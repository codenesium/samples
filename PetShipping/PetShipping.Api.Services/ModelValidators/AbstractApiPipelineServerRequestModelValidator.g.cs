using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineServerRequestModelValidator : AbstractValidator<ApiPipelineServerRequestModel>
	{
		private int existingRecordId;

		private IPipelineRepository pipelineRepository;

		public AbstractApiPipelineServerRequestModelValidator(IPipelineRepository pipelineRepository)
		{
			this.pipelineRepository = pipelineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PipelineStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStatusId).MustAsync(this.BeValidPipelineStatuByPipelineStatusId).When(x => !x?.PipelineStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
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
    <Hash>87d8bf2642902d9a317d0d1f31f3981e</Hash>
</Codenesium>*/