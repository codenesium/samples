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

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 255);
		}
	}
}

/*<Codenesium>
    <Hash>f995f8a3149f943c89a9176f72a41f35</Hash>
</Codenesium>*/