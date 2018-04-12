using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
	public class DeviceModelValidator: AbstractDeviceModelValidator, IDeviceModelValidator
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
    <Hash>0943eb29fc33a5f40289a4b5b9e8809f</Hash>
</Codenesium>*/