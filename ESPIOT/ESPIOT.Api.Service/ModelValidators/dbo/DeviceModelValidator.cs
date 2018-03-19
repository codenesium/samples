using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
	public class DeviceModelValidator: AbstractDeviceModelValidator,IDeviceModelValidator
	{
		public DeviceModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.PublicIdRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.PublicIdRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.PublicIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>ccf3792606f77e708039a428e3ae0df8</Hash>
</Codenesium>*/