using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public class TeamModelValidator: AbstractTeamModelValidator,ITeamModelValidator
	{
		public TeamModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.OrganizationIdRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.OrganizationIdRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.OrganizationIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>599714a4343d012cc8fecad25a6423cf</Hash>
</Codenesium>*/