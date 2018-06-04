using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services

{
	public abstract class AbstractApiPipelineRequestModelValidator: AbstractValidator<ApiPipelineRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiPipelineRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IPipelineStatusRepository PipelineStatusRepository { get; set; }
		public virtual void PipelineStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStatusId).NotNull();
			this.RuleFor(x => x.PipelineStatusId).MustAsync(this.BeValidPipelineStatus).When(x => x ?.PipelineStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void SaleIdRules()
		{
			this.RuleFor(x => x.SaleId).NotNull();
		}

		private async Task<bool> BeValidPipelineStatus(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PipelineStatusRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>18e42baf677bbf764ec3c8ea06388572</Hash>
</Codenesium>*/