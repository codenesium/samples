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
    <Hash>57cacb2c3ec0d566d9d11f8f1b8593a9</Hash>
</Codenesium>*/