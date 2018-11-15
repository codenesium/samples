using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
	public abstract class AbstractIntegrationTestMigration
	{
		protected ApplicationDbContext Context { get; private set; }

		public AbstractIntegrationTestMigration(ApplicationDbContext context)
		{
			this.Context = context;
		}

		public virtual async void Migrate()
		{
			var deviceItem1 = new Device();
			deviceItem1.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.Context.Devices.Add(deviceItem1);

			var deviceActionItem1 = new DeviceAction();
			deviceActionItem1.SetProperties("A", 1, 1, "A");
			this.Context.DeviceActions.Add(deviceActionItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>1e6af55dafebbfafacd4f67939791ab1</Hash>
</Codenesium>*/