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
    <Hash>d71330e1f43dd449c02a0244ff6776aa</Hash>
</Codenesium>*/