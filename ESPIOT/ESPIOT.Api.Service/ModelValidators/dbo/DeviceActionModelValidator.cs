using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
	public class DeviceActionModelValidator: AbstractDeviceActionModelValidator,IDeviceActionModelValidator
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

		public void PatchMode()
		{
			this.DeviceIdRules();
			this.NameRules();
			this.@ValueRules();
		}
	}
}

/*<Codenesium>
    <Hash>8aecf7377b3cdce0387d69f148a2fd12</Hash>
</Codenesium>*/