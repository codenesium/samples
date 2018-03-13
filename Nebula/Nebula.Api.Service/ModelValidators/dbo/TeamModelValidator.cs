using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class TeamModelValidator: TeamModelValidatorAbstract
	{
		public TeamModelValidator()
		{   }

		public void CreateMode()
		{
			this.IdRules();
			this.NameRules();
			this.OrganizationIdRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NameRules();
			this.OrganizationIdRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NameRules();
			this.OrganizationIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>e13b6511b7380f1d14ce3e7ea91f5253</Hash>
</Codenesium>*/