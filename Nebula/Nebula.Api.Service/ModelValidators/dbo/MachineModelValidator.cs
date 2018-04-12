using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class MachineModelValidator: AbstractMachineModelValidator, IMachineModelValidator
	{
		public MachineModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.MachineGuidRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.DescriptionRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.MachineGuidRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.DescriptionRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>04f591d1627adb393e489d2f0e9a8824</Hash>
</Codenesium>*/