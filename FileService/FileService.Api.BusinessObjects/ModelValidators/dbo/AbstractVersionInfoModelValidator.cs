using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects

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
    <Hash>2226954ebce566a93a96019108a7862b</Hash>
</Codenesium>*/