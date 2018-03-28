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
    <Hash>d323ca22e614de6f552ee0a25b4e8d60</Hash>
</Codenesium>*/