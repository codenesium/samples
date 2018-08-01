using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESPIOTNS.Api.DataAccess
{
	public class IntegrationTestMigration
	{
		private ApplicationDbContext context;

		public IntegrationTestMigration(ApplicationDbContext context)
		{
			this.context = context;
		}

		public void Migrate()
		{
			var deviceItem1 = new Device();
			deviceItem1.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.context.Devices.Add(deviceItem1);

			var deviceActionItem1 = new DeviceAction();
			deviceActionItem1.SetProperties(1, 1, "A", "A");
			this.context.DeviceActions.Add(deviceActionItem1);

			this.context.SaveChanges();
		}
	}
}

/*<Codenesium>
    <Hash>566533c859fee18c7de8a51d032e6c2a</Hash>
</Codenesium>*/