using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class ClaspModelValidator: AbstractClaspModelValidator, IClaspModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>0e7644a15b98be3505f9138743311901</Hash>
</Codenesium>*/