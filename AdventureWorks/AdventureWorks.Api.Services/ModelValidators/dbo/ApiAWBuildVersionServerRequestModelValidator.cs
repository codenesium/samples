using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiAWBuildVersionServerRequestModelValidator : AbstractApiAWBuildVersionServerRequestModelValidator, IApiAWBuildVersionServerRequestModelValidator
	{
		public ApiAWBuildVersionServerRequestModelValidator(IAWBuildVersionRepository aWBuildVersionRepository)
			: base(aWBuildVersionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionServerRequestModel model)
		{
			this.Database_VersionRules();
			this.ModifiedDateRules();
			this.VersionDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionServerRequestModel model)
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
    <Hash>ce1709aee4df81d2b4e04320bce85344</Hash>
</Codenesium>*/