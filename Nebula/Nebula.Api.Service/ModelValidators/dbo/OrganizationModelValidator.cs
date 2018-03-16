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
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
		}

		public void PatchMode()
		{
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>32d4f9661f3e3e9883717465443ccb32</Hash>
</Codenesium>*/