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
			this.IdRules();
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>22bae02ddd9bc2d8cde2313f62681fa6</Hash>
</Codenesium>*/