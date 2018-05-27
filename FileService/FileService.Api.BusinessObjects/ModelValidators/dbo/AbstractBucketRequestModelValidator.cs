using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects

{
	public abstract class AbstractApiBucketRequestModelValidator: AbstractValidator<ApiBucketRequestModel>
	{
		public new ValidationResult Validate(ApiBucketRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBucketRequestModel model)
		{
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
			var record = await this.BucketRepository.GetExternalId(model.ExternalId);

			return record == null;
		}
		private async Task<bool> BeUniqueGetName(ApiBucketRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.BucketRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>41aec9fee2c9224075789110008dda35</Hash>
</Codenesium>*/