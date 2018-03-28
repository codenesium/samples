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

		public void PatchMode()
		{
			this.NameRules();
			this.MachineGuidRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.DescriptionRules();
		}
	}
}

/*<Codenesium>
    <Hash>56d0ee6042eab0bacaab92c2c9dd81a2</Hash>
</Codenesium>*/