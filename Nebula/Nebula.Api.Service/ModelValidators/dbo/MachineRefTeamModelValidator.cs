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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>6cbc1b356e8274d516ab9dbb7288aaf0</Hash>
</Codenesium>*/