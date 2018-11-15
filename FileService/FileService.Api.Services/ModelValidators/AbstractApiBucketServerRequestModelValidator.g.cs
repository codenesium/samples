using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractApiBucketServerRequestModelValidator : AbstractValidator<ApiBucketServerRequestModel>
	{
		private int existingRecordId;

		private IBucketRepository bucketRepository;

		public AbstractApiBucketServerRequestModelValidator(IBucketRepository bucketRepository)
		{
			this.bucketRepository = bucketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBucketServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByExternalId).When(x => !x?.ExternalId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketServerRequestModel.ExternalId));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 255);
		}

		private async Task<bool> BeUniqueByExternalId(ApiBucketServerRequestModel model,  CancellationToken cancellationToken)
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

		private async Task<bool> BeUniqueByName(ApiBucketServerRequestModel model,  CancellationToken cancellationToken)
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
    <Hash>5d5ff16a136294bc59e20dfc327172dc</Hash>
</Codenesium>*/