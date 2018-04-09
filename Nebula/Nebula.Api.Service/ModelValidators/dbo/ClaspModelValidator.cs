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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>6eb834ae8bbbc14a2d915918a0b871ac</Hash>
</Codenesium>*/