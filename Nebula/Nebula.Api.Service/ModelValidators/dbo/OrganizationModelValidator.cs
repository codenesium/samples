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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>4724e6f0624c11a27431afd9a0f632ec</Hash>
</Codenesium>*/