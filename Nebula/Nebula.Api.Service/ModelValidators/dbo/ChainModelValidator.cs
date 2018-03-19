using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class ChainModelValidator: AbstractChainModelValidator,IChainModelValidator
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
    <Hash>32658bb1bfc7aad408c3210b1a86f663</Hash>
</Codenesium>*/