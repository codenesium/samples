using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects

{
	public abstract class AbstractBucketModelValidator: AbstractValidator<BucketModel>
	{
		public new ValidationResult Validate(BucketModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(BucketModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 255);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>0b741c4758a0feeccc5043eb93c973ad</Hash>
</Codenesium>*/