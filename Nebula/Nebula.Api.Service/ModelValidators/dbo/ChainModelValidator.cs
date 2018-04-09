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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>768929c65db643283bd11b7a724a0540</Hash>
</Codenesium>*/