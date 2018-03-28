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
			this.PublicIdRules();
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.PublicIdRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.PublicIdRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>f9e366533f43e174d3883f6dd42d1b95</Hash>
</Codenesium>*/