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
			this.LinkIdRules();
			this.LogRules();
		}

		public void UpdateMode()
		{
			this.DateEnteredRules();
			this.LinkIdRules();
			this.LogRules();
		}

		public void PatchMode()
		{
			this.DateEnteredRules();
			this.LinkIdRules();
			this.LogRules();
		}
	}
}

/*<Codenesium>
    <Hash>15d3ea300965555d3ebe9ff71557266f</Hash>
</Codenesium>*/