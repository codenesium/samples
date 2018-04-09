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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>9b17df627fdee3bd4c467cb2a11b9907</Hash>
</Codenesium>*/