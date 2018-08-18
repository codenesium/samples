using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
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
			var accountItem1 = new Account();
			accountItem1.SetProperties("A", "A", "A", "A", "A", "A", "A");
			this.context.Accounts.Add(accountItem1);

			var actionTemplateItem1 = new ActionTemplate();
			actionTemplateItem1.SetProperties("A", "A", "A", "A", "A", 1);
			this.context.ActionTemplates.Add(actionTemplateItem1);

			var actionTemplateVersionItem1 = new ActionTemplateVersion();
			actionTemplateVersionItem1.SetProperties("A", "A", "A", "A", "A", 1);
			this.context.ActionTemplateVersions.Add(actionTemplateVersionItem1);

			var apiKeyItem1 = new ApiKey();
			apiKeyItem1.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
			this.context.ApiKeys.Add(apiKeyItem1);

			var artifactItem1 = new Artifact();
			artifactItem1.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A");
			this.context.Artifacts.Add(artifactItem1);

			var certificateItem1 = new Certificate();
			certificateItem1.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
			this.context.Certificates.Add(certificateItem1);

			var channelItem1 = new Channel();
			channelItem1.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A", "A", "A");
			this.context.Channels.Add(channelItem1);

			var communityActionTemplateItem1 = new CommunityActionTemplate();
			communityActionTemplateItem1.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A", "A");
			this.context.CommunityActionTemplates.Add(communityActionTemplateItem1);

			var configurationItem1 = new Configuration();
			configurationItem1.SetProperties("A", "A");
			this.context.Configurations.Add(configurationItem1);

			var dashboardConfigurationItem1 = new DashboardConfiguration();
			dashboardConfigurationItem1.SetProperties("A", "A", "A", "A", "A", "A");
			this.context.DashboardConfigurations.Add(dashboardConfigurationItem1);

			var deploymentItem1 = new Deployment();
			deploymentItem1.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");
			this.context.Deployments.Add(deploymentItem1);

			var deploymentEnvironmentItem1 = new DeploymentEnvironment();
			deploymentEnvironmentItem1.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", 1);
			this.context.DeploymentEnvironments.Add(deploymentEnvironmentItem1);

			var deploymentHistoryItem1 = new DeploymentHistory();
			deploymentHistoryItem1.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", 1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A");
			this.context.DeploymentHistories.Add(deploymentHistoryItem1);

			var deploymentProcessItem1 = new DeploymentProcess();
			deploymentProcessItem1.SetProperties("A", true, "A", "A", "A", 1);
			this.context.DeploymentProcesses.Add(deploymentProcessItem1);

			var deploymentRelatedMachineItem1 = new DeploymentRelatedMachine();
			deploymentRelatedMachineItem1.SetProperties("A", 1, "A");
			this.context.DeploymentRelatedMachines.Add(deploymentRelatedMachineItem1);

			var eventItem1 = new Event();
			eventItem1.SetProperties(1, "A", "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A");
			this.context.Events.Add(eventItem1);

			var eventRelatedDocumentItem1 = new EventRelatedDocument();
			eventRelatedDocumentItem1.SetProperties("A", 1, "A");
			this.context.EventRelatedDocuments.Add(eventRelatedDocumentItem1);

			var extensionConfigurationItem1 = new ExtensionConfiguration();
			extensionConfigurationItem1.SetProperties("A", "A", "A", "A");
			this.context.ExtensionConfigurations.Add(extensionConfigurationItem1);

			var feedItem1 = new Feed();
			feedItem1.SetProperties("A", "A", "A", "A", "A");
			this.context.Feeds.Add(feedItem1);

			var interruptionItem1 = new Interruption();
			interruptionItem1.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A", "A", "A", "A");
			this.context.Interruptions.Add(interruptionItem1);

			var invitationItem1 = new Invitation();
			invitationItem1.SetProperties("A", "A", "A");
			this.context.Invitations.Add(invitationItem1);

			var keyAllocationItem1 = new KeyAllocation();
			keyAllocationItem1.SetProperties(1, "A");
			this.context.KeyAllocations.Add(keyAllocationItem1);

			var libraryVariableSetItem1 = new LibraryVariableSet();
			libraryVariableSetItem1.SetProperties("A", "A", "A", "A", "A");
			this.context.LibraryVariableSets.Add(libraryVariableSetItem1);

			var lifecycleItem1 = new Lifecycle();
			lifecycleItem1.SetProperties(BitConverter.GetBytes(1), "A", "A", "A");
			this.context.Lifecycles.Add(lifecycleItem1);

			var machineItem1 = new Machine();
			machineItem1.SetProperties("A", "A", "A", "A", true, "A", "A", "A", "A", "A", "A", "A", "A");
			this.context.Machines.Add(machineItem1);

			var machinePolicyItem1 = new MachinePolicy();
			machinePolicyItem1.SetProperties("A", true, "A", "A");
			this.context.MachinePolicies.Add(machinePolicyItem1);

			var mutexItem1 = new Mutex();
			mutexItem1.SetProperties("A", "A");
			this.context.Mutexes.Add(mutexItem1);

			var nuGetPackageItem1 = new NuGetPackage();
			nuGetPackageItem1.SetProperties("A", "A", "A", "A", 1, 1, 1, 1, "A");
			this.context.NuGetPackages.Add(nuGetPackageItem1);

			var octopusServerNodeItem1 = new OctopusServerNode();
			octopusServerNodeItem1.SetProperties("A", true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");
			this.context.OctopusServerNodes.Add(octopusServerNodeItem1);

			var projectItem1 = new Project();
			projectItem1.SetProperties(true, BitConverter.GetBytes(1), "A", true, "A", "A", true, "A", "A", "A", "A", "A", "A");
			this.context.Projects.Add(projectItem1);

			var projectGroupItem1 = new ProjectGroup();
			projectGroupItem1.SetProperties(BitConverter.GetBytes(1), "A", "A", "A");
			this.context.ProjectGroups.Add(projectGroupItem1);

			var projectTriggerItem1 = new ProjectTrigger();
			projectTriggerItem1.SetProperties("A", true, "A", "A", "A", "A");
			this.context.ProjectTriggers.Add(projectTriggerItem1);

			var proxyItem1 = new Proxy();
			proxyItem1.SetProperties("A", "A", "A");
			this.context.Proxies.Add(proxyItem1);

			var releaseItem1 = new Release();
			releaseItem1.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", "A", "A");
			this.context.Releases.Add(releaseItem1);

			var schemaVersionsItem1 = new SchemaVersions();
			schemaVersionsItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			this.context.SchemaVersions.Add(schemaVersionsItem1);

			var serverTaskItem1 = new ServerTask();
			serverTaskItem1.SetProperties(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", true, true, "A", "A", "A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			this.context.ServerTasks.Add(serverTaskItem1);

			var subscriptionItem1 = new Subscription();
			subscriptionItem1.SetProperties("A", true, "A", "A", "A");
			this.context.Subscriptions.Add(subscriptionItem1);

			var tagSetItem1 = new TagSet();
			tagSetItem1.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", 1);
			this.context.TagSets.Add(tagSetItem1);

			var teamItem1 = new Team();
			teamItem1.SetProperties("A", "A", "A", "A", "A", "A", "A", "A", "A");
			this.context.Teams.Add(teamItem1);

			var tenantItem1 = new Tenant();
			tenantItem1.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A", "A");
			this.context.Tenants.Add(tenantItem1);

			var tenantVariableItem1 = new TenantVariable();
			tenantVariableItem1.SetProperties("A", "A", "A", "A", "A", "A", "A");
			this.context.TenantVariables.Add(tenantVariableItem1);

			var userItem1 = new User();
			userItem1.SetProperties("A", "A", "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), true, true, "A", "A");
			this.context.Users.Add(userItem1);

			var userRoleItem1 = new UserRole();
			userRoleItem1.SetProperties("A", "A", "A");
			this.context.UserRoles.Add(userRoleItem1);

			var variableSetItem1 = new VariableSet();
			variableSetItem1.SetProperties("A", true, "A", "A", "A", 1);
			this.context.VariableSets.Add(variableSetItem1);

			var workerItem1 = new Worker();
			workerItem1.SetProperties("A", "A", "A", true, "A", "A", "A", "A", "A", "A");
			this.context.Workers.Add(workerItem1);

			var workerPoolItem1 = new WorkerPool();
			workerPoolItem1.SetProperties("A", true, "A", "A", 1);
			this.context.WorkerPools.Add(workerPoolItem1);

			var workerTaskLeaseItem1 = new WorkerTaskLease();
			workerTaskLeaseItem1.SetProperties(true, "A", "A", "A", "A", "A");
			this.context.WorkerTaskLeases.Add(workerTaskLeaseItem1);

			this.context.SaveChanges();
		}
	}
}

/*<Codenesium>
    <Hash>b05ed85d1bfe85a006cd9f28f0e3357e</Hash>
</Codenesium>*/