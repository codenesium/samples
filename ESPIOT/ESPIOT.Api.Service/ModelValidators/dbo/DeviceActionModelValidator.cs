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
			this.IdRules();
			this.NameRules();
			this.@ValueRules();
		}

		public void UpdateMode()
		{
			this.DeviceIdRules();
			this.IdRules();
			this.NameRules();
			this.@ValueRules();
		}

		public void PatchMode()
		{
			this.DeviceIdRules();
			this.IdRules();
			this.NameRules();
			this.@ValueRules();
		}
	}
}

/*<Codenesium>
    <Hash>08042fc5073ca6a8bbcc8cb4ca0d2df6</Hash>
</Codenesium>*/