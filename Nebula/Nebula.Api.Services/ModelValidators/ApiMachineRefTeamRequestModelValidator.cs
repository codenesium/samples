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
    <Hash>a7ebeee74ee410bbd6d0b29ad4fa99e2</Hash>
</Codenesium>*/