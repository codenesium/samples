using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class LinkLogModelValidator: LinkLogModelValidatorAbstract
	{
		public LinkLogModelValidator()
		{   }

		public void CreateMode()
		{
			this.DateEnteredRules();
			this.IdRules();
			this.LinkIdRules();
			this.LogRules();
		}

		public void UpdateMode()
		{
			this.DateEnteredRules();
			this.IdRules();
			this.LinkIdRules();
			this.LogRules();
		}

		public void PatchMode()
		{
			this.DateEnteredRules();
			this.IdRules();
			this.LinkIdRules();
			this.LogRules();
		}
	}
}

/*<Codenesium>
    <Hash>b1c1b672ae7e884e129cd389a1c16794</Hash>
</Codenesium>*/