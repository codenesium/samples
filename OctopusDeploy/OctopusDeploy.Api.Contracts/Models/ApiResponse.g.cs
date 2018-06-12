using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OctopusDeployNS.Api.Contracts
{
        public class ReferenceEntity<T>
        {
                [JsonProperty(PropertyName = "Value")]
                public T Value { get; private set; }

                [JsonProperty(PropertyName = "Object")]
                public string ReferenceObjectName { get; set; }

                public ReferenceEntity(T value, string referenceObjectName)
                {
                        this.Value = value;
                        this.ReferenceObjectName = referenceObjectName;
                }
        }

        public partial class ApiResponse
        {
                public ApiResponse()
                {
                }

                public void Merge(ApiResponse from)
                {
                        from.Accounts.ForEach(x => this.AddAccount(x));
                        from.ActionTemplates.ForEach(x => this.AddActionTemplate(x));
                        from.ActionTemplateVersions.ForEach(x => this.AddActionTemplateVersion(x));
                        from.ApiKeys.ForEach(x => this.AddApiKey(x));
                        from.Artifacts.ForEach(x => this.AddArtifact(x));
                        from.Certificates.ForEach(x => this.AddCertificate(x));
                        from.Channels.ForEach(x => this.AddChannel(x));
                        from.CommunityActionTemplates.ForEach(x => this.AddCommunityActionTemplate(x));
                        from.Configurations.ForEach(x => this.AddConfiguration(x));
                        from.DashboardConfigurations.ForEach(x => this.AddDashboardConfiguration(x));
                        from.Deployments.ForEach(x => this.AddDeployment(x));
                        from.DeploymentEnvironments.ForEach(x => this.AddDeploymentEnvironment(x));
                        from.DeploymentHistories.ForEach(x => this.AddDeploymentHistory(x));
                        from.DeploymentProcesses.ForEach(x => this.AddDeploymentProcess(x));
                        from.DeploymentRelatedMachines.ForEach(x => this.AddDeploymentRelatedMachine(x));
                        from.Events.ForEach(x => this.AddEvent(x));
                        from.EventRelatedDocuments.ForEach(x => this.AddEventRelatedDocument(x));
                        from.ExtensionConfigurations.ForEach(x => this.AddExtensionConfiguration(x));
                        from.Feeds.ForEach(x => this.AddFeed(x));
                        from.Interruptions.ForEach(x => this.AddInterruption(x));
                        from.Invitations.ForEach(x => this.AddInvitation(x));
                        from.KeyAllocations.ForEach(x => this.AddKeyAllocation(x));
                        from.LibraryVariableSets.ForEach(x => this.AddLibraryVariableSet(x));
                        from.Lifecycles.ForEach(x => this.AddLifecycle(x));
                        from.Machines.ForEach(x => this.AddMachine(x));
                        from.MachinePolicies.ForEach(x => this.AddMachinePolicy(x));
                        from.Mutexes.ForEach(x => this.AddMutex(x));
                        from.NuGetPackages.ForEach(x => this.AddNuGetPackage(x));
                        from.OctopusServerNodes.ForEach(x => this.AddOctopusServerNode(x));
                        from.Projects.ForEach(x => this.AddProject(x));
                        from.ProjectGroups.ForEach(x => this.AddProjectGroup(x));
                        from.ProjectTriggers.ForEach(x => this.AddProjectTrigger(x));
                        from.Proxies.ForEach(x => this.AddProxy(x));
                        from.Releases.ForEach(x => this.AddRelease(x));
                        from.SchemaVersions.ForEach(x => this.AddSchemaVersions(x));
                        from.ServerTasks.ForEach(x => this.AddServerTask(x));
                        from.Subscriptions.ForEach(x => this.AddSubscription(x));
                        from.TagSets.ForEach(x => this.AddTagSet(x));
                        from.Teams.ForEach(x => this.AddTeam(x));
                        from.Tenants.ForEach(x => this.AddTenant(x));
                        from.TenantVariables.ForEach(x => this.AddTenantVariable(x));
                        from.Users.ForEach(x => this.AddUser(x));
                        from.UserRoles.ForEach(x => this.AddUserRole(x));
                        from.VariableSets.ForEach(x => this.AddVariableSet(x));
                        from.Workers.ForEach(x => this.AddWorker(x));
                        from.WorkerPools.ForEach(x => this.AddWorkerPool(x));
                        from.WorkerTaskLeases.ForEach(x => this.AddWorkerTaskLease(x));
                }

                public List<ApiAccountResponseModel> Accounts { get; private set; } = new List<ApiAccountResponseModel>();

                public List<ApiActionTemplateResponseModel> ActionTemplates { get; private set; } = new List<ApiActionTemplateResponseModel>();

                public List<ApiActionTemplateVersionResponseModel> ActionTemplateVersions { get; private set; } = new List<ApiActionTemplateVersionResponseModel>();

                public List<ApiApiKeyResponseModel> ApiKeys { get; private set; } = new List<ApiApiKeyResponseModel>();

                public List<ApiArtifactResponseModel> Artifacts { get; private set; } = new List<ApiArtifactResponseModel>();

                public List<ApiCertificateResponseModel> Certificates { get; private set; } = new List<ApiCertificateResponseModel>();

                public List<ApiChannelResponseModel> Channels { get; private set; } = new List<ApiChannelResponseModel>();

                public List<ApiCommunityActionTemplateResponseModel> CommunityActionTemplates { get; private set; } = new List<ApiCommunityActionTemplateResponseModel>();

                public List<ApiConfigurationResponseModel> Configurations { get; private set; } = new List<ApiConfigurationResponseModel>();

                public List<ApiDashboardConfigurationResponseModel> DashboardConfigurations { get; private set; } = new List<ApiDashboardConfigurationResponseModel>();

                public List<ApiDeploymentResponseModel> Deployments { get; private set; } = new List<ApiDeploymentResponseModel>();

                public List<ApiDeploymentEnvironmentResponseModel> DeploymentEnvironments { get; private set; } = new List<ApiDeploymentEnvironmentResponseModel>();

                public List<ApiDeploymentHistoryResponseModel> DeploymentHistories { get; private set; } = new List<ApiDeploymentHistoryResponseModel>();

                public List<ApiDeploymentProcessResponseModel> DeploymentProcesses { get; private set; } = new List<ApiDeploymentProcessResponseModel>();

                public List<ApiDeploymentRelatedMachineResponseModel> DeploymentRelatedMachines { get; private set; } = new List<ApiDeploymentRelatedMachineResponseModel>();

                public List<ApiEventResponseModel> Events { get; private set; } = new List<ApiEventResponseModel>();

                public List<ApiEventRelatedDocumentResponseModel> EventRelatedDocuments { get; private set; } = new List<ApiEventRelatedDocumentResponseModel>();

                public List<ApiExtensionConfigurationResponseModel> ExtensionConfigurations { get; private set; } = new List<ApiExtensionConfigurationResponseModel>();

                public List<ApiFeedResponseModel> Feeds { get; private set; } = new List<ApiFeedResponseModel>();

                public List<ApiInterruptionResponseModel> Interruptions { get; private set; } = new List<ApiInterruptionResponseModel>();

                public List<ApiInvitationResponseModel> Invitations { get; private set; } = new List<ApiInvitationResponseModel>();

                public List<ApiKeyAllocationResponseModel> KeyAllocations { get; private set; } = new List<ApiKeyAllocationResponseModel>();

                public List<ApiLibraryVariableSetResponseModel> LibraryVariableSets { get; private set; } = new List<ApiLibraryVariableSetResponseModel>();

                public List<ApiLifecycleResponseModel> Lifecycles { get; private set; } = new List<ApiLifecycleResponseModel>();

                public List<ApiMachineResponseModel> Machines { get; private set; } = new List<ApiMachineResponseModel>();

                public List<ApiMachinePolicyResponseModel> MachinePolicies { get; private set; } = new List<ApiMachinePolicyResponseModel>();

                public List<ApiMutexResponseModel> Mutexes { get; private set; } = new List<ApiMutexResponseModel>();

                public List<ApiNuGetPackageResponseModel> NuGetPackages { get; private set; } = new List<ApiNuGetPackageResponseModel>();

                public List<ApiOctopusServerNodeResponseModel> OctopusServerNodes { get; private set; } = new List<ApiOctopusServerNodeResponseModel>();

                public List<ApiProjectResponseModel> Projects { get; private set; } = new List<ApiProjectResponseModel>();

                public List<ApiProjectGroupResponseModel> ProjectGroups { get; private set; } = new List<ApiProjectGroupResponseModel>();

                public List<ApiProjectTriggerResponseModel> ProjectTriggers { get; private set; } = new List<ApiProjectTriggerResponseModel>();

                public List<ApiProxyResponseModel> Proxies { get; private set; } = new List<ApiProxyResponseModel>();

                public List<ApiReleaseResponseModel> Releases { get; private set; } = new List<ApiReleaseResponseModel>();

                public List<ApiSchemaVersionsResponseModel> SchemaVersions { get; private set; } = new List<ApiSchemaVersionsResponseModel>();

                public List<ApiServerTaskResponseModel> ServerTasks { get; private set; } = new List<ApiServerTaskResponseModel>();

                public List<ApiSubscriptionResponseModel> Subscriptions { get; private set; } = new List<ApiSubscriptionResponseModel>();

                public List<ApiTagSetResponseModel> TagSets { get; private set; } = new List<ApiTagSetResponseModel>();

                public List<ApiTeamResponseModel> Teams { get; private set; } = new List<ApiTeamResponseModel>();

                public List<ApiTenantResponseModel> Tenants { get; private set; } = new List<ApiTenantResponseModel>();

                public List<ApiTenantVariableResponseModel> TenantVariables { get; private set; } = new List<ApiTenantVariableResponseModel>();

                public List<ApiUserResponseModel> Users { get; private set; } = new List<ApiUserResponseModel>();

                public List<ApiUserRoleResponseModel> UserRoles { get; private set; } = new List<ApiUserRoleResponseModel>();

                public List<ApiVariableSetResponseModel> VariableSets { get; private set; } = new List<ApiVariableSetResponseModel>();

                public List<ApiWorkerResponseModel> Workers { get; private set; } = new List<ApiWorkerResponseModel>();

                public List<ApiWorkerPoolResponseModel> WorkerPools { get; private set; } = new List<ApiWorkerPoolResponseModel>();

                public List<ApiWorkerTaskLeaseResponseModel> WorkerTaskLeases { get; private set; } = new List<ApiWorkerTaskLeaseResponseModel>();

                [JsonIgnore]
                public bool ShouldSerializeAccountsValue { get; private set; } = true;

                public bool ShouldSerializeAccounts()
                {
                        return this.ShouldSerializeAccountsValue;
                }

                public void AddAccount(ApiAccountResponseModel item)
                {
                        if (!this.Accounts.Any(x => x.Id == item.Id))
                        {
                                this.Accounts.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeActionTemplatesValue { get; private set; } = true;

                public bool ShouldSerializeActionTemplates()
                {
                        return this.ShouldSerializeActionTemplatesValue;
                }

                public void AddActionTemplate(ApiActionTemplateResponseModel item)
                {
                        if (!this.ActionTemplates.Any(x => x.Id == item.Id))
                        {
                                this.ActionTemplates.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeActionTemplateVersionsValue { get; private set; } = true;

                public bool ShouldSerializeActionTemplateVersions()
                {
                        return this.ShouldSerializeActionTemplateVersionsValue;
                }

                public void AddActionTemplateVersion(ApiActionTemplateVersionResponseModel item)
                {
                        if (!this.ActionTemplateVersions.Any(x => x.Id == item.Id))
                        {
                                this.ActionTemplateVersions.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeApiKeysValue { get; private set; } = true;

                public bool ShouldSerializeApiKeys()
                {
                        return this.ShouldSerializeApiKeysValue;
                }

                public void AddApiKey(ApiApiKeyResponseModel item)
                {
                        if (!this.ApiKeys.Any(x => x.Id == item.Id))
                        {
                                this.ApiKeys.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeArtifactsValue { get; private set; } = true;

                public bool ShouldSerializeArtifacts()
                {
                        return this.ShouldSerializeArtifactsValue;
                }

                public void AddArtifact(ApiArtifactResponseModel item)
                {
                        if (!this.Artifacts.Any(x => x.Id == item.Id))
                        {
                                this.Artifacts.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCertificatesValue { get; private set; } = true;

                public bool ShouldSerializeCertificates()
                {
                        return this.ShouldSerializeCertificatesValue;
                }

                public void AddCertificate(ApiCertificateResponseModel item)
                {
                        if (!this.Certificates.Any(x => x.Id == item.Id))
                        {
                                this.Certificates.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeChannelsValue { get; private set; } = true;

                public bool ShouldSerializeChannels()
                {
                        return this.ShouldSerializeChannelsValue;
                }

                public void AddChannel(ApiChannelResponseModel item)
                {
                        if (!this.Channels.Any(x => x.Id == item.Id))
                        {
                                this.Channels.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeCommunityActionTemplatesValue { get; private set; } = true;

                public bool ShouldSerializeCommunityActionTemplates()
                {
                        return this.ShouldSerializeCommunityActionTemplatesValue;
                }

                public void AddCommunityActionTemplate(ApiCommunityActionTemplateResponseModel item)
                {
                        if (!this.CommunityActionTemplates.Any(x => x.Id == item.Id))
                        {
                                this.CommunityActionTemplates.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeConfigurationsValue { get; private set; } = true;

                public bool ShouldSerializeConfigurations()
                {
                        return this.ShouldSerializeConfigurationsValue;
                }

                public void AddConfiguration(ApiConfigurationResponseModel item)
                {
                        if (!this.Configurations.Any(x => x.Id == item.Id))
                        {
                                this.Configurations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDashboardConfigurationsValue { get; private set; } = true;

                public bool ShouldSerializeDashboardConfigurations()
                {
                        return this.ShouldSerializeDashboardConfigurationsValue;
                }

                public void AddDashboardConfiguration(ApiDashboardConfigurationResponseModel item)
                {
                        if (!this.DashboardConfigurations.Any(x => x.Id == item.Id))
                        {
                                this.DashboardConfigurations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDeploymentsValue { get; private set; } = true;

                public bool ShouldSerializeDeployments()
                {
                        return this.ShouldSerializeDeploymentsValue;
                }

                public void AddDeployment(ApiDeploymentResponseModel item)
                {
                        if (!this.Deployments.Any(x => x.Id == item.Id))
                        {
                                this.Deployments.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDeploymentEnvironmentsValue { get; private set; } = true;

                public bool ShouldSerializeDeploymentEnvironments()
                {
                        return this.ShouldSerializeDeploymentEnvironmentsValue;
                }

                public void AddDeploymentEnvironment(ApiDeploymentEnvironmentResponseModel item)
                {
                        if (!this.DeploymentEnvironments.Any(x => x.Id == item.Id))
                        {
                                this.DeploymentEnvironments.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDeploymentHistoriesValue { get; private set; } = true;

                public bool ShouldSerializeDeploymentHistories()
                {
                        return this.ShouldSerializeDeploymentHistoriesValue;
                }

                public void AddDeploymentHistory(ApiDeploymentHistoryResponseModel item)
                {
                        if (!this.DeploymentHistories.Any(x => x.DeploymentId == item.DeploymentId))
                        {
                                this.DeploymentHistories.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDeploymentProcessesValue { get; private set; } = true;

                public bool ShouldSerializeDeploymentProcesses()
                {
                        return this.ShouldSerializeDeploymentProcessesValue;
                }

                public void AddDeploymentProcess(ApiDeploymentProcessResponseModel item)
                {
                        if (!this.DeploymentProcesses.Any(x => x.Id == item.Id))
                        {
                                this.DeploymentProcesses.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeDeploymentRelatedMachinesValue { get; private set; } = true;

                public bool ShouldSerializeDeploymentRelatedMachines()
                {
                        return this.ShouldSerializeDeploymentRelatedMachinesValue;
                }

                public void AddDeploymentRelatedMachine(ApiDeploymentRelatedMachineResponseModel item)
                {
                        if (!this.DeploymentRelatedMachines.Any(x => x.Id == item.Id))
                        {
                                this.DeploymentRelatedMachines.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeEventsValue { get; private set; } = true;

                public bool ShouldSerializeEvents()
                {
                        return this.ShouldSerializeEventsValue;
                }

                public void AddEvent(ApiEventResponseModel item)
                {
                        if (!this.Events.Any(x => x.Id == item.Id))
                        {
                                this.Events.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeEventRelatedDocumentsValue { get; private set; } = true;

                public bool ShouldSerializeEventRelatedDocuments()
                {
                        return this.ShouldSerializeEventRelatedDocumentsValue;
                }

                public void AddEventRelatedDocument(ApiEventRelatedDocumentResponseModel item)
                {
                        if (!this.EventRelatedDocuments.Any(x => x.Id == item.Id))
                        {
                                this.EventRelatedDocuments.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeExtensionConfigurationsValue { get; private set; } = true;

                public bool ShouldSerializeExtensionConfigurations()
                {
                        return this.ShouldSerializeExtensionConfigurationsValue;
                }

                public void AddExtensionConfiguration(ApiExtensionConfigurationResponseModel item)
                {
                        if (!this.ExtensionConfigurations.Any(x => x.Id == item.Id))
                        {
                                this.ExtensionConfigurations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeFeedsValue { get; private set; } = true;

                public bool ShouldSerializeFeeds()
                {
                        return this.ShouldSerializeFeedsValue;
                }

                public void AddFeed(ApiFeedResponseModel item)
                {
                        if (!this.Feeds.Any(x => x.Id == item.Id))
                        {
                                this.Feeds.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeInterruptionsValue { get; private set; } = true;

                public bool ShouldSerializeInterruptions()
                {
                        return this.ShouldSerializeInterruptionsValue;
                }

                public void AddInterruption(ApiInterruptionResponseModel item)
                {
                        if (!this.Interruptions.Any(x => x.Id == item.Id))
                        {
                                this.Interruptions.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeInvitationsValue { get; private set; } = true;

                public bool ShouldSerializeInvitations()
                {
                        return this.ShouldSerializeInvitationsValue;
                }

                public void AddInvitation(ApiInvitationResponseModel item)
                {
                        if (!this.Invitations.Any(x => x.Id == item.Id))
                        {
                                this.Invitations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeKeyAllocationsValue { get; private set; } = true;

                public bool ShouldSerializeKeyAllocations()
                {
                        return this.ShouldSerializeKeyAllocationsValue;
                }

                public void AddKeyAllocation(ApiKeyAllocationResponseModel item)
                {
                        if (!this.KeyAllocations.Any(x => x.CollectionName == item.CollectionName))
                        {
                                this.KeyAllocations.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeLibraryVariableSetsValue { get; private set; } = true;

                public bool ShouldSerializeLibraryVariableSets()
                {
                        return this.ShouldSerializeLibraryVariableSetsValue;
                }

                public void AddLibraryVariableSet(ApiLibraryVariableSetResponseModel item)
                {
                        if (!this.LibraryVariableSets.Any(x => x.Id == item.Id))
                        {
                                this.LibraryVariableSets.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeLifecyclesValue { get; private set; } = true;

                public bool ShouldSerializeLifecycles()
                {
                        return this.ShouldSerializeLifecyclesValue;
                }

                public void AddLifecycle(ApiLifecycleResponseModel item)
                {
                        if (!this.Lifecycles.Any(x => x.Id == item.Id))
                        {
                                this.Lifecycles.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeMachinesValue { get; private set; } = true;

                public bool ShouldSerializeMachines()
                {
                        return this.ShouldSerializeMachinesValue;
                }

                public void AddMachine(ApiMachineResponseModel item)
                {
                        if (!this.Machines.Any(x => x.Id == item.Id))
                        {
                                this.Machines.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeMachinePoliciesValue { get; private set; } = true;

                public bool ShouldSerializeMachinePolicies()
                {
                        return this.ShouldSerializeMachinePoliciesValue;
                }

                public void AddMachinePolicy(ApiMachinePolicyResponseModel item)
                {
                        if (!this.MachinePolicies.Any(x => x.Id == item.Id))
                        {
                                this.MachinePolicies.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeMutexesValue { get; private set; } = true;

                public bool ShouldSerializeMutexes()
                {
                        return this.ShouldSerializeMutexesValue;
                }

                public void AddMutex(ApiMutexResponseModel item)
                {
                        if (!this.Mutexes.Any(x => x.Id == item.Id))
                        {
                                this.Mutexes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeNuGetPackagesValue { get; private set; } = true;

                public bool ShouldSerializeNuGetPackages()
                {
                        return this.ShouldSerializeNuGetPackagesValue;
                }

                public void AddNuGetPackage(ApiNuGetPackageResponseModel item)
                {
                        if (!this.NuGetPackages.Any(x => x.Id == item.Id))
                        {
                                this.NuGetPackages.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeOctopusServerNodesValue { get; private set; } = true;

                public bool ShouldSerializeOctopusServerNodes()
                {
                        return this.ShouldSerializeOctopusServerNodesValue;
                }

                public void AddOctopusServerNode(ApiOctopusServerNodeResponseModel item)
                {
                        if (!this.OctopusServerNodes.Any(x => x.Id == item.Id))
                        {
                                this.OctopusServerNodes.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectsValue { get; private set; } = true;

                public bool ShouldSerializeProjects()
                {
                        return this.ShouldSerializeProjectsValue;
                }

                public void AddProject(ApiProjectResponseModel item)
                {
                        if (!this.Projects.Any(x => x.Id == item.Id))
                        {
                                this.Projects.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectGroupsValue { get; private set; } = true;

                public bool ShouldSerializeProjectGroups()
                {
                        return this.ShouldSerializeProjectGroupsValue;
                }

                public void AddProjectGroup(ApiProjectGroupResponseModel item)
                {
                        if (!this.ProjectGroups.Any(x => x.Id == item.Id))
                        {
                                this.ProjectGroups.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectTriggersValue { get; private set; } = true;

                public bool ShouldSerializeProjectTriggers()
                {
                        return this.ShouldSerializeProjectTriggersValue;
                }

                public void AddProjectTrigger(ApiProjectTriggerResponseModel item)
                {
                        if (!this.ProjectTriggers.Any(x => x.Id == item.Id))
                        {
                                this.ProjectTriggers.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeProxiesValue { get; private set; } = true;

                public bool ShouldSerializeProxies()
                {
                        return this.ShouldSerializeProxiesValue;
                }

                public void AddProxy(ApiProxyResponseModel item)
                {
                        if (!this.Proxies.Any(x => x.Id == item.Id))
                        {
                                this.Proxies.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeReleasesValue { get; private set; } = true;

                public bool ShouldSerializeReleases()
                {
                        return this.ShouldSerializeReleasesValue;
                }

                public void AddRelease(ApiReleaseResponseModel item)
                {
                        if (!this.Releases.Any(x => x.Id == item.Id))
                        {
                                this.Releases.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSchemaVersionsValue { get; private set; } = true;

                public bool ShouldSerializeSchemaVersions()
                {
                        return this.ShouldSerializeSchemaVersionsValue;
                }

                public void AddSchemaVersions(ApiSchemaVersionsResponseModel item)
                {
                        if (!this.SchemaVersions.Any(x => x.Id == item.Id))
                        {
                                this.SchemaVersions.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeServerTasksValue { get; private set; } = true;

                public bool ShouldSerializeServerTasks()
                {
                        return this.ShouldSerializeServerTasksValue;
                }

                public void AddServerTask(ApiServerTaskResponseModel item)
                {
                        if (!this.ServerTasks.Any(x => x.Id == item.Id))
                        {
                                this.ServerTasks.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeSubscriptionsValue { get; private set; } = true;

                public bool ShouldSerializeSubscriptions()
                {
                        return this.ShouldSerializeSubscriptionsValue;
                }

                public void AddSubscription(ApiSubscriptionResponseModel item)
                {
                        if (!this.Subscriptions.Any(x => x.Id == item.Id))
                        {
                                this.Subscriptions.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeTagSetsValue { get; private set; } = true;

                public bool ShouldSerializeTagSets()
                {
                        return this.ShouldSerializeTagSetsValue;
                }

                public void AddTagSet(ApiTagSetResponseModel item)
                {
                        if (!this.TagSets.Any(x => x.Id == item.Id))
                        {
                                this.TagSets.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeTeamsValue { get; private set; } = true;

                public bool ShouldSerializeTeams()
                {
                        return this.ShouldSerializeTeamsValue;
                }

                public void AddTeam(ApiTeamResponseModel item)
                {
                        if (!this.Teams.Any(x => x.Id == item.Id))
                        {
                                this.Teams.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantsValue { get; private set; } = true;

                public bool ShouldSerializeTenants()
                {
                        return this.ShouldSerializeTenantsValue;
                }

                public void AddTenant(ApiTenantResponseModel item)
                {
                        if (!this.Tenants.Any(x => x.Id == item.Id))
                        {
                                this.Tenants.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantVariablesValue { get; private set; } = true;

                public bool ShouldSerializeTenantVariables()
                {
                        return this.ShouldSerializeTenantVariablesValue;
                }

                public void AddTenantVariable(ApiTenantVariableResponseModel item)
                {
                        if (!this.TenantVariables.Any(x => x.Id == item.Id))
                        {
                                this.TenantVariables.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeUsersValue { get; private set; } = true;

                public bool ShouldSerializeUsers()
                {
                        return this.ShouldSerializeUsersValue;
                }

                public void AddUser(ApiUserResponseModel item)
                {
                        if (!this.Users.Any(x => x.Id == item.Id))
                        {
                                this.Users.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeUserRolesValue { get; private set; } = true;

                public bool ShouldSerializeUserRoles()
                {
                        return this.ShouldSerializeUserRolesValue;
                }

                public void AddUserRole(ApiUserRoleResponseModel item)
                {
                        if (!this.UserRoles.Any(x => x.Id == item.Id))
                        {
                                this.UserRoles.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeVariableSetsValue { get; private set; } = true;

                public bool ShouldSerializeVariableSets()
                {
                        return this.ShouldSerializeVariableSetsValue;
                }

                public void AddVariableSet(ApiVariableSetResponseModel item)
                {
                        if (!this.VariableSets.Any(x => x.Id == item.Id))
                        {
                                this.VariableSets.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeWorkersValue { get; private set; } = true;

                public bool ShouldSerializeWorkers()
                {
                        return this.ShouldSerializeWorkersValue;
                }

                public void AddWorker(ApiWorkerResponseModel item)
                {
                        if (!this.Workers.Any(x => x.Id == item.Id))
                        {
                                this.Workers.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeWorkerPoolsValue { get; private set; } = true;

                public bool ShouldSerializeWorkerPools()
                {
                        return this.ShouldSerializeWorkerPoolsValue;
                }

                public void AddWorkerPool(ApiWorkerPoolResponseModel item)
                {
                        if (!this.WorkerPools.Any(x => x.Id == item.Id))
                        {
                                this.WorkerPools.Add(item);
                        }
                }

                [JsonIgnore]
                public bool ShouldSerializeWorkerTaskLeasesValue { get; private set; } = true;

                public bool ShouldSerializeWorkerTaskLeases()
                {
                        return this.ShouldSerializeWorkerTaskLeasesValue;
                }

                public void AddWorkerTaskLease(ApiWorkerTaskLeaseResponseModel item)
                {
                        if (!this.WorkerTaskLeases.Any(x => x.Id == item.Id))
                        {
                                this.WorkerTaskLeases.Add(item);
                        }
                }

                public void DisableSerializationOfEmptyFields()
                {
                        if (this.Accounts.Count == 0)
                        {
                                this.ShouldSerializeAccountsValue = false;
                        }

                        if (this.ActionTemplates.Count == 0)
                        {
                                this.ShouldSerializeActionTemplatesValue = false;
                        }

                        if (this.ActionTemplateVersions.Count == 0)
                        {
                                this.ShouldSerializeActionTemplateVersionsValue = false;
                        }

                        if (this.ApiKeys.Count == 0)
                        {
                                this.ShouldSerializeApiKeysValue = false;
                        }

                        if (this.Artifacts.Count == 0)
                        {
                                this.ShouldSerializeArtifactsValue = false;
                        }

                        if (this.Certificates.Count == 0)
                        {
                                this.ShouldSerializeCertificatesValue = false;
                        }

                        if (this.Channels.Count == 0)
                        {
                                this.ShouldSerializeChannelsValue = false;
                        }

                        if (this.CommunityActionTemplates.Count == 0)
                        {
                                this.ShouldSerializeCommunityActionTemplatesValue = false;
                        }

                        if (this.Configurations.Count == 0)
                        {
                                this.ShouldSerializeConfigurationsValue = false;
                        }

                        if (this.DashboardConfigurations.Count == 0)
                        {
                                this.ShouldSerializeDashboardConfigurationsValue = false;
                        }

                        if (this.Deployments.Count == 0)
                        {
                                this.ShouldSerializeDeploymentsValue = false;
                        }

                        if (this.DeploymentEnvironments.Count == 0)
                        {
                                this.ShouldSerializeDeploymentEnvironmentsValue = false;
                        }

                        if (this.DeploymentHistories.Count == 0)
                        {
                                this.ShouldSerializeDeploymentHistoriesValue = false;
                        }

                        if (this.DeploymentProcesses.Count == 0)
                        {
                                this.ShouldSerializeDeploymentProcessesValue = false;
                        }

                        if (this.DeploymentRelatedMachines.Count == 0)
                        {
                                this.ShouldSerializeDeploymentRelatedMachinesValue = false;
                        }

                        if (this.Events.Count == 0)
                        {
                                this.ShouldSerializeEventsValue = false;
                        }

                        if (this.EventRelatedDocuments.Count == 0)
                        {
                                this.ShouldSerializeEventRelatedDocumentsValue = false;
                        }

                        if (this.ExtensionConfigurations.Count == 0)
                        {
                                this.ShouldSerializeExtensionConfigurationsValue = false;
                        }

                        if (this.Feeds.Count == 0)
                        {
                                this.ShouldSerializeFeedsValue = false;
                        }

                        if (this.Interruptions.Count == 0)
                        {
                                this.ShouldSerializeInterruptionsValue = false;
                        }

                        if (this.Invitations.Count == 0)
                        {
                                this.ShouldSerializeInvitationsValue = false;
                        }

                        if (this.KeyAllocations.Count == 0)
                        {
                                this.ShouldSerializeKeyAllocationsValue = false;
                        }

                        if (this.LibraryVariableSets.Count == 0)
                        {
                                this.ShouldSerializeLibraryVariableSetsValue = false;
                        }

                        if (this.Lifecycles.Count == 0)
                        {
                                this.ShouldSerializeLifecyclesValue = false;
                        }

                        if (this.Machines.Count == 0)
                        {
                                this.ShouldSerializeMachinesValue = false;
                        }

                        if (this.MachinePolicies.Count == 0)
                        {
                                this.ShouldSerializeMachinePoliciesValue = false;
                        }

                        if (this.Mutexes.Count == 0)
                        {
                                this.ShouldSerializeMutexesValue = false;
                        }

                        if (this.NuGetPackages.Count == 0)
                        {
                                this.ShouldSerializeNuGetPackagesValue = false;
                        }

                        if (this.OctopusServerNodes.Count == 0)
                        {
                                this.ShouldSerializeOctopusServerNodesValue = false;
                        }

                        if (this.Projects.Count == 0)
                        {
                                this.ShouldSerializeProjectsValue = false;
                        }

                        if (this.ProjectGroups.Count == 0)
                        {
                                this.ShouldSerializeProjectGroupsValue = false;
                        }

                        if (this.ProjectTriggers.Count == 0)
                        {
                                this.ShouldSerializeProjectTriggersValue = false;
                        }

                        if (this.Proxies.Count == 0)
                        {
                                this.ShouldSerializeProxiesValue = false;
                        }

                        if (this.Releases.Count == 0)
                        {
                                this.ShouldSerializeReleasesValue = false;
                        }

                        if (this.SchemaVersions.Count == 0)
                        {
                                this.ShouldSerializeSchemaVersionsValue = false;
                        }

                        if (this.ServerTasks.Count == 0)
                        {
                                this.ShouldSerializeServerTasksValue = false;
                        }

                        if (this.Subscriptions.Count == 0)
                        {
                                this.ShouldSerializeSubscriptionsValue = false;
                        }

                        if (this.TagSets.Count == 0)
                        {
                                this.ShouldSerializeTagSetsValue = false;
                        }

                        if (this.Teams.Count == 0)
                        {
                                this.ShouldSerializeTeamsValue = false;
                        }

                        if (this.Tenants.Count == 0)
                        {
                                this.ShouldSerializeTenantsValue = false;
                        }

                        if (this.TenantVariables.Count == 0)
                        {
                                this.ShouldSerializeTenantVariablesValue = false;
                        }

                        if (this.Users.Count == 0)
                        {
                                this.ShouldSerializeUsersValue = false;
                        }

                        if (this.UserRoles.Count == 0)
                        {
                                this.ShouldSerializeUserRolesValue = false;
                        }

                        if (this.VariableSets.Count == 0)
                        {
                                this.ShouldSerializeVariableSetsValue = false;
                        }

                        if (this.Workers.Count == 0)
                        {
                                this.ShouldSerializeWorkersValue = false;
                        }

                        if (this.WorkerPools.Count == 0)
                        {
                                this.ShouldSerializeWorkerPoolsValue = false;
                        }

                        if (this.WorkerTaskLeases.Count == 0)
                        {
                                this.ShouldSerializeWorkerTaskLeasesValue = false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b88ff8379665bcc8b1f98d76ce273dae</Hash>
</Codenesium>*/