using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
	public class IntegrationTestMigration
	{
		private ApplicationDbContext context;

		public IntegrationTestMigration(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async void Migrate()
		{
			var deviceItem1 = new Device();
			deviceItem1.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.context.Devices.Add(deviceItem1);

			var deviceActionItem1 = new DeviceAction();
			deviceActionItem1.SetProperties(1, 1, "A", "A");
			this.context.DeviceActions.Add(deviceActionItem1);

			await this.context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>c7aa261e4001380f08d64d5ce58ee7cb</Hash>
</Codenesium>*/