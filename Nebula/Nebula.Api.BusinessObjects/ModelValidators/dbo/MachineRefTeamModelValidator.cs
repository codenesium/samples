using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class MachineRefTeamModelValidator: AbstractMachineRefTeamModelValidator, IMachineRefTeamModelValidator
	{
		public MachineRefTeamModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(MachineRefTeamModel model)
		{
			this.MachineIdRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, MachineRefTeamModel model)
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
    <Hash>3f1701bdbee4ed8c331c38e89ec75deb</Hash>
</Codenesium>*/