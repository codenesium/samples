using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class LinkStatusModelValidator: AbstractLinkStatusModelValidator, ILinkStatusModelValidator
	{
		public LinkStatusModelValidator()
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
    <Hash>027c9599008408132b39159450883961</Hash>
</Codenesium>*/