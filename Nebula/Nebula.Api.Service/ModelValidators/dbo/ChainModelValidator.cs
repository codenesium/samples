using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class ChainModelValidator: ChainModelValidatorAbstract
	{
		public ChainModelValidator()
		{   }

		public void CreateMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
			this.TeamIdRules();
		}

		public void UpdateMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
			this.TeamIdRules();
		}

		public void PatchMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
			this.TeamIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>3631bccc7c402e64ed5eecf3269203fa</Hash>
</Codenesium>*/