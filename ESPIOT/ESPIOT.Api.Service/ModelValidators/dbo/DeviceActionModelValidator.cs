using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
	public class DeviceActionModelValidator: AbstractDeviceActionModelValidator, IDeviceActionModelValidator
	{
		public DeviceActionModelValidator()
		{   }

		public void CreateMode()
		{
			this.DeviceIdRules();
			this.NameRules();
			this.@ValueRules();
		}

		public void UpdateMode()
		{
			this.DeviceIdRules();
			this.NameRules();
			this.@ValueRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>9e4d494a22bf91640f7da857f18a13dc</Hash>
</Codenesium>*/