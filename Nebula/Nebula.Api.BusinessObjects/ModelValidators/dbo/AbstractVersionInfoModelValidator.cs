using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractVersionInfoModelValidator: AbstractValidator<VersionInfoModel>
	{
		public new ValidationResult Validate(VersionInfoModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(VersionInfoModel model)
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
    <Hash>a6f24944ebd50d5b1e304e8bdfac5905</Hash>
</Codenesium>*/