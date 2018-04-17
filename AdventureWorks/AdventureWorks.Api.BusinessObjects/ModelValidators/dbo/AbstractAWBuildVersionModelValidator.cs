using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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
			this.RuleFor(x => x.Database_Version).NotNull();
			this.RuleFor(x => x.Database_Version).Length(0, 25);
		}

		public virtual void VersionDateRules()
		{
			this.RuleFor(x => x.VersionDate).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>5ab9cee63080332997c181a3e813fe17</Hash>
</Codenesium>*/