using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class ChainStatusModelValidator: ChainStatusModelValidatorAbstract
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
    <Hash>e27b9cac2cd479001844cfde29343589</Hash>
</Codenesium>*/