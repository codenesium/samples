using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class ClaspModelValidator: ClaspModelValidatorAbstract
	{
		public ClaspModelValidator()
		{   }

		public void CreateMode()
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}

		public void UpdateMode()
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}

		public void PatchMode()
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>20da6125bae92081a892d931dd4df629</Hash>
</Codenesium>*/