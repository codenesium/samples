using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
	public class DeviceModelValidator: DeviceModelValidatorAbstract
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
    <Hash>a1c03a1d2728fbae7a4318a27e203421</Hash>
</Codenesium>*/