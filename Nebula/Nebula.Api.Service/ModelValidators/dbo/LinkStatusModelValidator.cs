using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class LinkStatusModelValidator: LinkStatusModelValidatorAbstract
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
    <Hash>f6f3c8e08ef951cd72ef593872b199ed</Hash>
</Codenesium>*/