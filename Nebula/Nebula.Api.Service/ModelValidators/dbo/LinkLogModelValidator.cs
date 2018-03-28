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
			this.LinkIdRules();
			this.LogRules();
			this.DateEnteredRules();
		}

		public void UpdateMode()
		{
			this.LinkIdRules();
			this.LogRules();
			this.DateEnteredRules();
		}

		public void PatchMode()
		{
			this.LinkIdRules();
			this.LogRules();
			this.DateEnteredRules();
		}
	}
}

/*<Codenesium>
    <Hash>b26a6c3a19309e1da8082d530d6d82c8</Hash>
</Codenesium>*/