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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>839f51b6d999e30e8f7b7ec4cdbd15e1</Hash>
</Codenesium>*/