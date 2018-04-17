using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class AWBuildVersionModelValidator: AbstractAWBuildVersionModelValidator, IAWBuildVersionModelValidator
	{
		public AWBuildVersionModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(AWBuildVersionModel model)
		{
			this.Database_VersionRules();
			this.VersionDateRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, AWBuildVersionModel model)
		{
			this.Database_VersionRules();
			this.VersionDateRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>25e450d4d40ebb7b957114d187393f6d</Hash>
</Codenesium>*/