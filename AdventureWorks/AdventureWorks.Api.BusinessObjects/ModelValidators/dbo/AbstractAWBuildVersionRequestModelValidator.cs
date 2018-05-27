using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiAWBuildVersionRequestModelValidator: AbstractValidator<ApiAWBuildVersionRequestModel>
	{
		public new ValidationResult Validate(ApiAWBuildVersionRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiAWBuildVersionRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void Database_VersionRules()
		{
			this.RuleFor(x => x.Database_Version).NotNull();
			this.RuleFor(x => x.Database_Version).Length(0, 25);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void VersionDateRules()
		{
			this.RuleFor(x => x.VersionDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>50f21cb373cf0f4e00c3cfbb8bd00884</Hash>
</Codenesium>*/