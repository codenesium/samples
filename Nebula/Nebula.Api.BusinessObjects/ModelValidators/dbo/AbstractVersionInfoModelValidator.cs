using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

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
    <Hash>2feb1ea957792062431c0ef9df051a5e</Hash>
</Codenesium>*/