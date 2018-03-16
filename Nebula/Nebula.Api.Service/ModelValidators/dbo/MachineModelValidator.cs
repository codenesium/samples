using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class MachineModelValidator: MachineModelValidatorAbstract
	{
		public MachineModelValidator()
		{   }

		public void CreateMode()
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>e579358baa1c5e6da1e75002a7ab2038</Hash>
</Codenesium>*/