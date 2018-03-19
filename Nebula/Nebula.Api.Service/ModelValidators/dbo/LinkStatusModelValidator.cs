using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class LinkStatusModelValidator: AbstractLinkStatusModelValidator,ILinkStatusModelValidator
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

		public void PatchMode()
		{
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>3685967e62614c58b08ac3f22bf86d9c</Hash>
</Codenesium>*/