using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiAWBuildVersionModelValidator: AbstractApiAWBuildVersionModelValidator, IApiAWBuildVersionModelValidator
	{
		public ApiAWBuildVersionModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionModel model)
		{
			this.Database_VersionRules();
			this.ModifiedDateRules();
			this.VersionDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionModel model)
		{
			this.Database_VersionRules();
			this.ModifiedDateRules();
			this.VersionDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>344e4d43fa75af8332d903a127aa7f5c</Hash>
</Codenesium>*/