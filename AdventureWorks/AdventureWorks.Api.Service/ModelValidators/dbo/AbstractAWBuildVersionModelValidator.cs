using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractAWBuildVersionModelValidator: AbstractValidator<AWBuildVersionModel>
	{
		public new ValidationResult Validate(AWBuildVersionModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(AWBuildVersionModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void Database_VersionRules()
		{
			RuleFor(x => x.Database_Version).NotNull();
			RuleFor(x => x.Database_Version).Length(0,25);
		}

		public virtual void VersionDateRules()
		{
			RuleFor(x => x.VersionDate).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>df032aecfb369d1a222a82ffd3762c1b</Hash>
</Codenesium>*/