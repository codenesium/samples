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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>15a1affd152f50efcb2ea2edcf52b45d</Hash>
</Codenesium>*/