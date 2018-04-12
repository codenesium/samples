using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class OrganizationModelValidator: AbstractOrganizationModelValidator, IOrganizationModelValidator
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
    <Hash>2c1ac494672a969d91b9d0fb288646fe</Hash>
</Codenesium>*/