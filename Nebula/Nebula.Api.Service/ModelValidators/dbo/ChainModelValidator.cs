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
			this.NameRules();
			this.TeamIdRules();
			this.ChainStatusIdRules();
			this.ExternalIdRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.TeamIdRules();
			this.ChainStatusIdRules();
			this.ExternalIdRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.TeamIdRules();
			this.ChainStatusIdRules();
			this.ExternalIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>4e4f540e3cad55054ca3fbb5ee1a9313</Hash>
</Codenesium>*/