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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>b75c8d9e04a6522ad35dd364a0144a66</Hash>
</Codenesium>*/