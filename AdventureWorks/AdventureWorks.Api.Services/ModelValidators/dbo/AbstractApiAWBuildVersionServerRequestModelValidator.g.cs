using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiAWBuildVersionServerRequestModelValidator : AbstractValidator<ApiAWBuildVersionServerRequestModel>
	{
		private int existingRecordId;

		private IAWBuildVersionRepository aWBuildVersionRepository;

		public AbstractApiAWBuildVersionServerRequestModelValidator(IAWBuildVersionRepository aWBuildVersionRepository)
		{
			this.aWBuildVersionRepository = aWBuildVersionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAWBuildVersionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void Database_VersionRules()
		{
			this.RuleFor(x => x.Database_Version).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Database_Version).Length(0, 25).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void VersionDateRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>be933e4ee5e55593334ce23cbc594345</Hash>
</Codenesium>*/