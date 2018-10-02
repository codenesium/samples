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
	public abstract class AbstractApiPipelineStepRequestModelValidator : AbstractValidator<ApiPipelineStepRequestModel>
	{
		private int existingRecordId;

		private IPipelineStepRepository pipelineStepRepository;

		public AbstractApiPipelineStepRequestModelValidator(IPipelineStepRepository pipelineStepRepository)
		{
			this.pipelineStepRepository = pipelineStepRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void PipelineStepStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStepStatusId).MustAsync(this.BeValidPipelineStepStatu).When(x => x?.PipelineStepStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ShipperIdRules()
		{
			this.RuleFor(x => x.ShipperId).MustAsync(this.BeValidEmployee).When(x => x?.ShipperId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidPipelineStepStatu(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepRepository.GetPipelineStepStatu(id);

			return record != null;
		}

		private async Task<bool> BeValidEmployee(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepRepository.GetEmployee(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a8f8d935d3dddbd0c29e53ad85ce0a44</Hash>
</Codenesium>*/