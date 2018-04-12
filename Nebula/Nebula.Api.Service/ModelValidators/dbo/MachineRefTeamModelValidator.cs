using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class MachineRefTeamModelValidator: AbstractMachineRefTeamModelValidator, IMachineRefTeamModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>ca6563cd295e7d5a63315703ca53bdfe</Hash>
</Codenesium>*/