using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public class ApiTeamRequestModelValidator: AbstractApiTeamRequestModelValidator, IApiTeamRequestModelValidator
	{
		public ApiTeamRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>2d7b1f450876eec31f7243f4afbffb50</Hash>
</Codenesium>*/