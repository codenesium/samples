using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class MachineRefTeamModelValidator: MachineRefTeamModelValidatorAbstract
	{
		public MachineRefTeamModelValidator()
		{   }

		public void CreateMode()
		{
			this.IdRules();
			this.MachineIdRules();
			this.TeamIdRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.MachineIdRules();
			this.TeamIdRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.MachineIdRules();
			this.TeamIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>e660da1652a59e706c00b15407f67014</Hash>
</Codenesium>*/