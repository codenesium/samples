using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class ClaspModelValidator: AbstractClaspModelValidator,IClaspModelValidator
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
    <Hash>a6ac27c313eb1e2565547c6faadf94bc</Hash>
</Codenesium>*/