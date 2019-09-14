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
	public class ApiBucketServerRequestModelValidator : AbstractValidator<ApiBucketServerRequestModel>, IApiBucketServerRequestModelValidator
	{
		private int existingRecordId;

		protected IBucketRepository BucketRepository { get; private set; }

		public ApiBucketServerRequestModelValidator(IBucketRepository bucketRepository)
		{
			this.BucketRepository = bucketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBucketServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBucketServerRequestModel model)
		{
			this.ExternalIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketServerRequestModel model)
		{
			this.ExternalIdRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>6f0adbd6ed70d9c0f02789d54a6ff0ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/