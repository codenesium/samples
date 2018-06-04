using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Services

{
	public abstract class AbstractApiBucketRequestModelValidator: AbstractValidator<ApiBucketRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiBucketRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBucketRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IBucketRepository BucketRepository { get; set; }
		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetExternalId).When(x => x ?.ExternalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketRequestModel.ExternalId));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 255);
		}

		private async Task<bool> BeUniqueGetExternalId(ApiBucketRequestModel model,  CancellationToken cancellationToken)
		{
			Bucket record = await this.BucketRepository.GetExternalId(model.ExternalId);

			if(record == null || record.Id == this.existingRecordId)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private async Task<bool> BeUniqueGetName(ApiBucketRequestModel model,  CancellationToken cancellationToken)
		{
			Bucket record = await this.BucketRepository.GetName(model.Name);

			if(record == null || record.Id == this.existingRecordId)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>48f5ba3a64fc75ebdb45b684c6ec64d5</Hash>
</Codenesium>*/