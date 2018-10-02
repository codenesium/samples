using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
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
			var chainItem1 = new Chain();
			chainItem1.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1);
			this.context.Chains.Add(chainItem1);

			var chainStatuItem1 = new ChainStatu();
			chainStatuItem1.SetProperties(1, "A");
			this.context.ChainStatus.Add(chainStatuItem1);

			var claspItem1 = new Clasp();
			claspItem1.SetProperties(1, 1, 1);
			this.context.Clasps.Add(claspItem1);

			var linkItem1 = new Link();
			linkItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", 1, "A", "A", 1);
			this.context.Links.Add(linkItem1);

			var linkLogItem1 = new LinkLog();
			linkLogItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			this.context.LinkLogs.Add(linkLogItem1);

			var linkStatuItem1 = new LinkStatu();
			linkStatuItem1.SetProperties(1, "A");
			this.context.LinkStatus.Add(linkStatuItem1);

			var machineItem1 = new Machine();
			machineItem1.SetProperties("A", 1, "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			this.context.Machines.Add(machineItem1);

			var machineRefTeamItem1 = new MachineRefTeam();
			machineRefTeamItem1.SetProperties(1, 1, 1);
			this.context.MachineRefTeams.Add(machineRefTeamItem1);

			var organizationItem1 = new Organization();
			organizationItem1.SetProperties(1, "A");
			this.context.Organizations.Add(organizationItem1);

			var sysdiagramItem1 = new Sysdiagram();
			sysdiagramItem1.SetProperties(BitConverter.GetBytes(1), 1, "A", 1, 1);
			this.context.Sysdiagrams.Add(sysdiagramItem1);

			var teamItem1 = new Team();
			teamItem1.SetProperties(1, "A", 1);
			this.context.Teams.Add(teamItem1);

			var versionInfoItem1 = new VersionInfo();
			versionInfoItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			this.context.VersionInfoes.Add(versionInfoItem1);

			await this.context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>fa88db112ac8ee1586bd34ee7f13769f</Hash>
</Codenesium>*/