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
	public class ApiPipelineServerRequestModelValidator : AbstractValidator<ApiPipelineServerRequestModel>, IApiPipelineServerRequestModelValidator
	{
		private int existingRecordId;

		protected IPipelineRepository PipelineRepository { get; private set; }

		public ApiPipelineServerRequestModelValidator(IPipelineRepository pipelineRepository)
		{
			this.PipelineRepository = pipelineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineServerRequestModel model)
		{
			this.PipelineStatusIdRules();
			this.SaleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineServerRequestModel model)
		{
			this.PipelineStatusIdRules();
			this.SaleIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void PipelineStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStatusId).MustAsync(this.BeValidPipelineStatusByPipelineStatusId).When(x => !x?.PipelineStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void SaleIdRules()
		{
		}

		protected async Task<bool> BeValidPipelineStatusByPipelineStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineRepository.PipelineStatusByPipelineStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>2ad5decaa18a7570ff5ff796ef81a394</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/