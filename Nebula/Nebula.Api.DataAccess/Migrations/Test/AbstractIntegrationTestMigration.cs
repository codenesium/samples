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
			var chainItem1 = new Chain();
			chainItem1.SetProperties(1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			this.Context.Chains.Add(chainItem1);

			var chainStatusItem1 = new ChainStatus();
			chainStatusItem1.SetProperties(1, "A");
			this.Context.ChainStatus.Add(chainStatusItem1);

			var claspItem1 = new Clasp();
			claspItem1.SetProperties(1, 1, 1);
			this.Context.Clasps.Add(claspItem1);

			var linkItem1 = new Link();
			linkItem1.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			this.Context.Links.Add(linkItem1);

			var linkLogItem1 = new LinkLog();
			linkLogItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			this.Context.LinkLogs.Add(linkLogItem1);

			var linkStatusItem1 = new LinkStatus();
			linkStatusItem1.SetProperties(1, "A");
			this.Context.LinkStatus.Add(linkStatusItem1);

			var machineItem1 = new Machine();
			machineItem1.SetProperties(1, "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			this.Context.Machines.Add(machineItem1);

			var organizationItem1 = new Organization();
			organizationItem1.SetProperties(1, "A");
			this.Context.Organizations.Add(organizationItem1);

			var teamItem1 = new Team();
			teamItem1.SetProperties(1, "A", 1);
			this.Context.Teams.Add(teamItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>05dd3e00ec69687bac14c32711259f38</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/