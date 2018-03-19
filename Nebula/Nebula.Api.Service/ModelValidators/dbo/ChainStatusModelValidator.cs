using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class ChainStatusModelValidator: AbstractChainStatusModelValidator,IChainStatusModelValidator
	{
		public ChainStatusModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
		}

		public void PatchMode()
		{
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>8557e48f8645128fd16a41eb62fb2c62</Hash>
</Codenesium>*/