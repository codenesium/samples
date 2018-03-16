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
    <Hash>56a52569b8206307ccec52eeb5bdf5e4</Hash>
</Codenesium>*/