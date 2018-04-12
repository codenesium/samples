using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class ChainStatusModelValidator: AbstractChainStatusModelValidator, IChainStatusModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>ee61a8a001ef9d0172552631a1208134</Hash>
</Codenesium>*/