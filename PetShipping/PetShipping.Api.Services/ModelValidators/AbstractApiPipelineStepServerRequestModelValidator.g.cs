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

		private IPipelineStepRepository pipelineStepRepository;

		public AbstractApiPipelineStepServerRequestModelValidator(IPipelineStepRepository pipelineStepRepository)
		{
			this.pipelineStepRepository = pipelineStepRepository;
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
			this.RuleFor(x => x.PipelineStepStatusId).MustAsync(this.BeValidPipelineStepStatuByPipelineStepStatusId).When(x => !x?.PipelineStepStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ShipperIdRules()
		{
			this.RuleFor(x => x.ShipperId).MustAsync(this.BeValidEmployeeByShipperId).When(x => !x?.ShipperId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		private async Task<bool> BeValidPipelineStepStatuByPipelineStepStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepRepository.PipelineStepStatuByPipelineStepStatusId(id);

			return record != null;
		}

		private async Task<bool> BeValidEmployeeByShipperId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.pipelineStepRepository.EmployeeByShipperId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>9e7d365a4762733517e4963cc56f0225</Hash>
</Codenesium>*/