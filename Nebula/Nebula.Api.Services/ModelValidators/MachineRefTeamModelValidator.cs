using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public class ApiMachineRefTeamRequestModelValidator: AbstractApiMachineRefTeamRequestModelValidator, IApiMachineRefTeamRequestModelValidator
	{
		public ApiMachineRefTeamRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamRequestModel model)
		{
			this.MachineIdRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamRequestModel model)
		{
			this.MachineIdRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4e0a616754f5c8a7538b83b339c6853e</Hash>
</Codenesium>*/