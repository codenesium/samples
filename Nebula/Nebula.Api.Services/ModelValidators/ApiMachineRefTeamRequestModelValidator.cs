using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiMachineRefTeamRequestModelValidator : AbstractApiMachineRefTeamRequestModelValidator, IApiMachineRefTeamRequestModelValidator
	{
		public ApiMachineRefTeamRequestModelValidator(IMachineRefTeamRepository machineRefTeamRepository)
			: base(machineRefTeamRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>104ffcc17db0a92650d4ae285fbe39d7</Hash>
</Codenesium>*/