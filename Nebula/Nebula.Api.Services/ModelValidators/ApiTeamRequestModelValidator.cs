using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiTeamRequestModelValidator : AbstractApiTeamRequestModelValidator, IApiTeamRequestModelValidator
	{
		public ApiTeamRequestModelValidator(ITeamRepository teamRepository)
			: base(teamRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model)
		{
			this.NameRules();
			this.OrganizationIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamRequestModel model)
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
    <Hash>b9c08f46529e3d7bc8e23237dffab177</Hash>
</Codenesium>*/