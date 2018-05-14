using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiTeamModelValidator: AbstractApiTeamModelValidator, IApiTeamModelValidator
	{
		public ApiTeamModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeamModel model)
		{
			this.NameRules();
			this.OrganizationIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamModel model)
		{
			this.NameRules();
			this.OrganizationIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>9156fd2dc7d60c1d0cc8c604ee25d85d</Hash>
</Codenesium>*/