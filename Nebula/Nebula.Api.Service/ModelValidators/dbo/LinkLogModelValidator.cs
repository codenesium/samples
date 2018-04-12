using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class LinkLogModelValidator: AbstractLinkLogModelValidator, ILinkLogModelValidator
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
    <Hash>5d472aa0e4202c050523715874fdef22</Hash>
</Codenesium>*/