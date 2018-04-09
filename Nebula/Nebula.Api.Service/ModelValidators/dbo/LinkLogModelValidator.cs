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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>82856482b461a119000a3d2868388df3</Hash>
</Codenesium>*/