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
			this.IdRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.DescriptionRules();
			this.IdRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.DescriptionRules();
			this.IdRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>449febe2b4075a1a7d5887202f5679c6</Hash>
</Codenesium>*/