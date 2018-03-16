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
    <Hash>3d4bf98003f6673c458d476ffc12434a</Hash>
</Codenesium>*/