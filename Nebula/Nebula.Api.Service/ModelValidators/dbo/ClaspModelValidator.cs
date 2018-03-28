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
			this.PreviousChainIdRules();
			this.NextChainIdRules();
		}

		public void UpdateMode()
		{
			this.PreviousChainIdRules();
			this.NextChainIdRules();
		}

		public void PatchMode()
		{
			this.PreviousChainIdRules();
			this.NextChainIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>528b2ba88b714ef4b0ffd4b37f3626bf</Hash>
</Codenesium>*/