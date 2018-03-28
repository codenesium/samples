using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service

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
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,255);
		}

		public virtual void ExternalIdRules()
		{
			RuleFor(x => x.ExternalId).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>6adc28f0ac7ddb6cdb25ca9540b78f97</Hash>
</Codenesium>*/