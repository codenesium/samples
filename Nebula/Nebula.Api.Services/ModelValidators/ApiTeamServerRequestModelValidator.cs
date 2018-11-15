using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiTeamServerRequestModelValidator : AbstractApiTeamServerRequestModelValidator, IApiTeamServerRequestModelValidator
	{
		public ApiTeamServerRequestModelValidator(ITeamRepository teamRepository)
			: base(teamRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeamServerRequestModel model)
		{
			this.NameRules();
			this.OrganizationIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamServerRequestModel model)
		{
			this.NameRules();
			this.OrganizationIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>013aa9506ed04a1ed62ab2306836e8ec</Hash>
</Codenesium>*/