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
	public abstract class AbstractApiBucketServerRequestModelValidator : AbstractValidator<ApiBucketServerRequestModel>
	{
		private int existingRecordId;

		protected IBucketRepository BucketRepository { get; private set; }

		public AbstractApiBucketServerRequestModelValidator(IBucketRepository bucketRepository)
		{
			this.BucketRepository = bucketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBucketServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByExternalId).When(x => (!x?.ExternalId.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketServerRequestModel.ExternalId)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 255).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByExternalId(ApiBucketServerRequestModel model,  CancellationToken cancellationToken)
		{
			Bucket record = await this.BucketRepository.ByExternalId(model.ExternalId);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByName(ApiBucketServerRequestModel model,  CancellationToken cancellationToken)
		{
			Bucket record = await this.BucketRepository.ByName(model.Name);

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
    <Hash>5332b69ba09d95a38c48f832c1bbb590</Hash>
</Codenesium>*/