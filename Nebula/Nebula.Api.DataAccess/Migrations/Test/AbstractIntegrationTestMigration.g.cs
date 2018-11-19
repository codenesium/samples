using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractIntegrationTestMigration
	{
		protected ApplicationDbContext Context { get; private set; }

		public AbstractIntegrationTestMigration(ApplicationDbContext context)
		{
			this.Context = context;
		}

		public virtual async Task Migrate()
		{
			var chainStatusItem1 = new ChainStatus();
			chainStatusItem1.SetProperties(1, "A");
			this.Context.ChainStatuses.Add(chainStatusItem1);

			var linkItem1 = new Link();
			linkItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", 1, "A", "A", 1);
			this.Context.Links.Add(linkItem1);

			var linkLogItem1 = new LinkLog();
			linkLogItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			this.Context.LinkLogs.Add(linkLogItem1);

			var linkStatusItem1 = new LinkStatus();
			linkStatusItem1.SetProperties(1, "A");
			this.Context.LinkStatuses.Add(linkStatusItem1);

			var machineItem1 = new Machine();
			machineItem1.SetProperties("A", 1, "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			this.Context.Machines.Add(machineItem1);

			var organizationItem1 = new Organization();
			organizationItem1.SetProperties(1, "A");
			this.Context.Organizations.Add(organizationItem1);

			var teamItem1 = new Team();
			teamItem1.SetProperties(1, "A", 1);
			this.Context.Teams.Add(teamItem1);

			var versionInfoItem1 = new VersionInfo();
			versionInfoItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			this.Context.VersionInfoes.Add(versionInfoItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>59c8daa29b42198a0f61f1f54e784aae</Hash>
</Codenesium>*/