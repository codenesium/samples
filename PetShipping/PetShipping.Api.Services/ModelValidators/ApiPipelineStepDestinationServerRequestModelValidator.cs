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
	public class ApiPipelineStepDestinationServerRequestModelValidator : AbstractValidator<ApiPipelineStepDestinationServerRequestModel>, IApiPipelineStepDestinationServerRequestModelValidator
	{
		private int existingRecordId;

		protected IPipelineStepDestinationRepository PipelineStepDestinationRepository { get; private set; }

		public ApiPipelineStepDestinationServerRequestModelValidator(IPipelineStepDestinationRepository pipelineStepDestinationRepository)
		{
			this.PipelineStepDestinationRepository = pipelineStepDestinationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStepDestinationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationServerRequestModel model)
		{
			this.DestinationIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationServerRequestModel model)
		{
			this.DestinationIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void DestinationIdRules()
		{
			this.RuleFor(x => x.DestinationId).MustAsync(this.BeValidDestinationByDestinationId).When(x => !x?.DestinationId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStepByPipelineStepId).When(x => !x?.PipelineStepId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidDestinationByDestinationId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepDestinationRepository.DestinationByDestinationId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPipelineStepByPipelineStepId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStepDestinationRepository.PipelineStepByPipelineStepId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>0d8b701e933d0a2f41e3a0f117165fdf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/