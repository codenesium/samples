using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class TeamModelValidator: AbstractTeamModelValidator, ITeamModelValidator
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
    <Hash>5863d3a091b836ca3fcd393b0ea6fe1a</Hash>
</Codenesium>*/