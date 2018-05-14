using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects

{
	public abstract class AbstractApiVersionInfoModelValidator: AbstractValidator<ApiVersionInfoModel>
	{
		public new ValidationResult Validate(ApiVersionInfoModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiVersionInfoModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void AppliedOnRules()
		{                       }

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).Length(0, 1024);
		}
	}
}

/*<Codenesium>
    <Hash>c615553901fbe213dba656d793f85a55</Hash>
</Codenesium>*/