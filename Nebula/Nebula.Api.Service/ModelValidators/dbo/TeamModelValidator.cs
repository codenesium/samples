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
    <Hash>a8d2f41545903bb35db3795ca3f55766</Hash>
</Codenesium>*/