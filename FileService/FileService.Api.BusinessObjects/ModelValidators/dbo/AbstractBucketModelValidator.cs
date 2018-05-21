using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects

{
	public abstract class AbstractApiBucketModelValidator: AbstractValidator<ApiBucketModel>
	{
		public new ValidationResult Validate(ApiBucketModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBucketModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBucketRepository BucketRepository { get; set; }
		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueExternalId).When(x => x ?.ExternalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketModel.ExternalId));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBucketModel.Name));
			this.RuleFor(x => x.Name).Length(0, 255);
		}

		private bool BeUniqueName(ApiBucketModel model)
		{
			return this.BucketRepository.Name(model.Name) == null;
		}

		private bool BeUniqueExternalId(ApiBucketModel model)
		{
			return this.BucketRepository.ExternalId(model.ExternalId) == null;
		}
	}
}

/*<Codenesium>
    <Hash>1231619bcae1f404336f6c79c702e70c</Hash>
</Codenesium>*/