using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class OrganizationModelValidator: AbstractOrganizationModelValidator,IOrganizationModelValidator
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
    <Hash>bf3ce57becf6b6a9ddcd9fa387924cfa</Hash>
</Codenesium>*/