using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
	public class DeviceModelValidator: DeviceModelValidatorAbstract
	{
		public DeviceModelValidator()
		{   }

		public void CreateMode()
		{
			this.IdRules();
			this.NameRules();
			this.PublicIdRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NameRules();
			this.PublicIdRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NameRules();
			this.PublicIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>ed1c496901c10c192ff310c86454a444</Hash>
</Codenesium>*/