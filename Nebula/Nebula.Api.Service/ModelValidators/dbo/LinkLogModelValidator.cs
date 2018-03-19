using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class LinkLogModelValidator: AbstractLinkLogModelValidator,ILinkLogModelValidator
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
    <Hash>55a94428dbff57de42cbb5ea99b1035d</Hash>
</Codenesium>*/