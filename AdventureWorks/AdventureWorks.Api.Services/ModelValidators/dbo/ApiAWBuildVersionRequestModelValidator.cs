using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiAWBuildVersionRequestModelValidator : AbstractApiAWBuildVersionRequestModelValidator, IApiAWBuildVersionRequestModelValidator
	{
		public ApiAWBuildVersionRequestModelValidator(IAWBuildVersionRepository aWBuildVersionRepository)
			: base(aWBuildVersionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionRequestModel model)
		{
			this.Database_VersionRules();
			this.ModifiedDateRules();
			this.VersionDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionRequestModel model)
		{
			this.Database_VersionRules();
			this.ModifiedDateRules();
			this.VersionDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>0c1dfe2f410dcf773a8ce22fa6dd751a</Hash>
</Codenesium>*/