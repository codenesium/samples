using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiMachineRefTeamServerRequestModelValidator : AbstractApiMachineRefTeamServerRequestModelValidator, IApiMachineRefTeamServerRequestModelValidator
	{
		public ApiMachineRefTeamServerRequestModelValidator(IMachineRefTeamRepository machineRefTeamRepository)
			: base(machineRefTeamRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamServerRequestModel model)
		{
			this.MachineIdRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamServerRequestModel model)
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
    <Hash>85b3d0d08a8bc4f192618a3bdcc891fa</Hash>
</Codenesium>*/