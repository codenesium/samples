using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects

{
	public abstract class AbstractApiFileTypeModelValidator: AbstractValidator<ApiFileTypeModel>
	{
		public new ValidationResult Validate(ApiFileTypeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiFileTypeModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 255);
		}
	}
}

/*<Codenesium>
    <Hash>e4d3ff77abcd83c52c36016274019f33</Hash>
</Codenesium>*/