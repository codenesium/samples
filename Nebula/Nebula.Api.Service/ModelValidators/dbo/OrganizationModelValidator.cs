using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class OrganizationModelValidator: OrganizationModelValidatorAbstract
	{
		public OrganizationModelValidator()
		{   }

		public void CreateMode()
		{
			this.IdRules();
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>d1affd075fac4bb5355917db2d729818</Hash>
</Codenesium>*/