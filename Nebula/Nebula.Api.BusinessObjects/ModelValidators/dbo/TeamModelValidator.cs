using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class TeamModelValidator: AbstractTeamModelValidator, ITeamModelValidator
	{
		public TeamModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(TeamModel model)
		{
			this.NameRules();
			this.OrganizationIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, TeamModel model)
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
    <Hash>8f4832683194ff2a6374516661d6821f</Hash>
</Codenesium>*/