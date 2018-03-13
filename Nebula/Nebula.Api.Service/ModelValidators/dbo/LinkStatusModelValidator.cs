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
			this.IdRules();
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>6893f3aefe40ecffd2514127a4f2db4c</Hash>
</Codenesium>*/