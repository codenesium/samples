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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>106aac424961526c3bb5d5ff5ccb4987</Hash>
</Codenesium>*/