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
	public class ApiPipelineStepServerRequestModelValidator : AbstractValidator<ApiPipelineStepServerRequestModel>, IApiPipelineStepServerRequestModelValidator
	{
		private int existingRecordId;

		protected IPipelineStepRepository PipelineStepRepository { get; private set; }

		public ApiPipelineStepServerRequestModelValidator(IPipelineStepRepository pipelineStepRepository)
		{
			this.PipelineStepRepository = pipelineStepRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepServerRequestModel model)
		{
			this.NameRules();
			this.PipelineStepStatusIdRules();
			this.ShipperIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepServerRequestModel model)
		{
			this.NameRules();
			this.PipelineStepStatusIdRules();
			this.ShipperIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>08db1e5bd286c7dd8c86e965f9a1f82e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/