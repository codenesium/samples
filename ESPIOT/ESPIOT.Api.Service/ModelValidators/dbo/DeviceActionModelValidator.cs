using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
	public class DeviceActionModelValidator: DeviceActionModelValidatorAbstract
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
    <Hash>de635dcc3e762fcbde97fe254e9375bc</Hash>
</Codenesium>*/