using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class MachineRefTeamModelValidator: AbstractMachineRefTeamModelValidator,IMachineRefTeamModelValidator
	{
		public MachineRefTeamModelValidator()
		{   }

		public void CreateMode()
		{
			this.MachineIdRules();
			this.TeamIdRules();
		}

		public void UpdateMode()
		{
			this.MachineIdRules();
			this.TeamIdRules();
		}

		public void PatchMode()
		{
			this.MachineIdRules();
			this.TeamIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>6df3c88912b3be57e36cfe35df56424e</Hash>
</Codenesium>*/