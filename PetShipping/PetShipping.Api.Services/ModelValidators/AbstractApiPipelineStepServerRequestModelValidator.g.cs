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
	public abstract class AbstractApiPipelineStepServerRequestModelValidator : AbstractValidator<ApiPipelineStepServerRequestModel>
	{
		private int existingRecordId;

		protected IPipelineStepRepository PipelineStepRepository { get; private set; }

		public AbstractApiPipelineStepServerRequestModelValidator(IPipelineStepRepository pipelineStepRepository)
		{
			this.PipelineStepRepository = pipelineStepRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PipelineStepStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStepStatusId).MustAsync(this.BeValidPipelineStepStatusByPipelineStepStatusId).When(x => !x?.PipelineStepStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ShipperIdRules()
		{
			this.RuleFor(x => x.ShipperId).MustAsync(this.BeValidEmployeeByShipperId).When(x => !x?.ShipperId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPipelineStepStatusByPipelineStepStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepRepository.PipelineStepStatusByPipelineStepStatusId(id);

			return record != null;
		}

		protected async Task<bool> BeValidEmployeeByShipperId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepRepository.EmployeeByShipperId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>412a75a6f11a78004946a151188c58d5</Hash>
</Codenesium>*/