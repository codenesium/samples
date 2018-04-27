using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class VersionInfoModelValidator: AbstractVersionInfoModelValidator, IVersionInfoModelValidator
	{
		public VersionInfoModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(VersionInfoModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(long id, VersionInfoModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(long id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>2c3b8b3c3a7d451786dc4dc3fd1ca0d7</Hash>
</Codenesium>*/