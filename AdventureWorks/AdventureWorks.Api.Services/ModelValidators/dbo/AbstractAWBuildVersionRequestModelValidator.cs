using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiAWBuildVersionRequestModelValidator: AbstractValidator<ApiAWBuildVersionRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiAWBuildVersionRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiAWBuildVersionRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>ad162be20f7cf2af884d60d51641f84c</Hash>
</Codenesium>*/