using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractApiBucketRequestModelValidator : AbstractValidator<ApiBucketRequestModel>
	{
		private int existingRecordId;

		private IBucketRepository bucketRepository;

		public AbstractApiBucketRequestModelValidator(IBucketRepository bucketRepository)
		{
			this.bucketRepository = bucketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBucketRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByExternalId).When(x => x?.ExternalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketRequestModel.ExternalId));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 255);
		}

		private async Task<bool> BeUniqueByExternalId(ApiBucketRequestModel model,  CancellationToken cancellationToken)
		{
			Bucket record = await this.bucketRepository.ByExternalId(model.ExternalId);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByName(ApiBucketRequestModel model,  CancellationToken cancellationToken)
		{
			Bucket record = await this.bucketRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
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
    <Hash>1b407affb9843f6f1fb9b15dbd2cb3a2</Hash>
</Codenesium>*/