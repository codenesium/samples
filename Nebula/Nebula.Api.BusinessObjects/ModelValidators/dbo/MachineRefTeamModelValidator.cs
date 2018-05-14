using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiMachineRefTeamModelValidator: AbstractApiMachineRefTeamModelValidator, IApiMachineRefTeamModelValidator
	{
		public ApiMachineRefTeamModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamModel model)
		{
			this.MachineIdRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamModel model)
		{
			this.MachineIdRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>bd683d82917e0e0da5d911b6391d97c8</Hash>
</Codenesium>*/