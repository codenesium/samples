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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>0cd705f00d8fc480a4c95db0ffd04ee4</Hash>
</Codenesium>*/