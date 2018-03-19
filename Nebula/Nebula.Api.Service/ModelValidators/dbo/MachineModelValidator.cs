using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class MachineModelValidator: AbstractMachineModelValidator,IMachineModelValidator
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
    <Hash>daa095fbe2f2e4469d1076e1a124a7ff</Hash>
</Codenesium>*/