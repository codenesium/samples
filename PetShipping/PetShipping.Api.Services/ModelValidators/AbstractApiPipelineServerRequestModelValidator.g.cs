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
	public abstract class AbstractApiPipelineServerRequestModelValidator : AbstractValidator<ApiPipelineServerRequestModel>
	{
		private int existingRecordId;

		protected IPipelineRepository PipelineRepository { get; private set; }

		public AbstractApiPipelineServerRequestModelValidator(IPipelineRepository pipelineRepository)
		{
			this.PipelineRepository = pipelineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PipelineStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStatusId).MustAsync(this.BeValidPipelineStatuByPipelineStatusId).When(x => !x?.PipelineStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void SaleIdRules()
		{
		}

		protected async Task<bool> BeValidPipelineStatuByPipelineStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineRepository.PipelineStatuByPipelineStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>9888d28213908c6431eb3089f2135abf</Hash>
</Codenesium>*/