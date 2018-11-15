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
			this.RuleFor(x => x.Database_Version).NotNull();
			this.RuleFor(x => x.Database_Version).Length(0, 25);
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
    <Hash>c5e82b0c13f5617577aabcdd66ed3a58</Hash>
</Codenesium>*/