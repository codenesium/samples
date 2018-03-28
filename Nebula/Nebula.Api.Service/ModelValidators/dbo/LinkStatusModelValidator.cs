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
    <Hash>fd69943eacf8787101abe495a0171534</Hash>
</Codenesium>*/