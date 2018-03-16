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
			this.NameRules();
			this.TeamIdRules();
		}

		public void UpdateMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.NameRules();
			this.TeamIdRules();
		}

		public void PatchMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.NameRules();
			this.TeamIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>7848dc4499c7314db40bcd8c9d46ee14</Hash>
</Codenesium>*/