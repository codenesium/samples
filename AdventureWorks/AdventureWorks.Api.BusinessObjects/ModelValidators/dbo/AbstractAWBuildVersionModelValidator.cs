using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiAWBuildVersionModelValidator: AbstractValidator<ApiAWBuildVersionModel>
	{
		public new ValidationResult Validate(ApiAWBuildVersionModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiAWBuildVersionModel model)
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
    <Hash>e45f6d43fca3f5ddbeb28176890f9e7c</Hash>
</Codenesium>*/