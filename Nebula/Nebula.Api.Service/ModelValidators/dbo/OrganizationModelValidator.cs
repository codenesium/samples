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
    <Hash>e52c87988f6520fda6dafaeb40c7353a</Hash>
</Codenesium>*/