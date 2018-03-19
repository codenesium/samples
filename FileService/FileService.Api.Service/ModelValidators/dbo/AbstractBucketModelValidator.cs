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

		public virtual void ExternalIdRules()
		{
			RuleFor(x => x.ExternalId).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,255);
		}
	}
}

/*<Codenesium>
    <Hash>57834f8318187d0562dc3db5177e8339</Hash>
</Codenesium>*/