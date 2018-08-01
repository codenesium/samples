using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLAccountMapper BOLAccountMapperMock { get; set; } = new BOLAccountMapper();

		public IBOLActionTemplateMapper BOLActionTemplateMapperMock { get; set; } = new BOLActionTemplateMapper();

		public IBOLActionTemplateVersionMapper BOLActionTemplateVersionMapperMock { get; set; } = new BOLActionTemplateVersionMapper();

		public IBOLApiKeyMapper BOLApiKeyMapperMock { get; set; } = new BOLApiKeyMapper();

		public IBOLArtifactMapper BOLArtifactMapperMock { get; set; } = new BOLArtifactMapper();

		public IBOLCertificateMapper BOLCertificateMapperMock { get; set; } = new BOLCertificateMapper();

		public IBOLChannelMapper BOLChannelMapperMock { get; set; } = new BOLChannelMapper();

		public IBOLCommunityActionTemplateMapper BOLCommunityActionTemplateMapperMock { get; set; } = new BOLCommunityActionTemplateMapper();

		public IBOLConfigurationMapper BOLConfigurationMapperMock { get; set; } = new BOLConfigurationMapper();

		public IBOLDashboardConfigurationMapper BOLDashboardConfigurationMapperMock { get; set; } = new BOLDashboardConfigurationMapper();

		public IBOLDeploymentMapper BOLDeploymentMapperMock { get; set; } = new BOLDeploymentMapper();

		public IBOLDeploymentEnvironmentMapper BOLDeploymentEnvironmentMapperMock { get; set; } = new BOLDeploymentEnvironmentMapper();

		public IBOLDeploymentHistoryMapper BOLDeploymentHistoryMapperMock { get; set; } = new BOLDeploymentHistoryMapper();

		public IBOLDeploymentProcessMapper BOLDeploymentProcessMapperMock { get; set; } = new BOLDeploymentProcessMapper();

		public IBOLDeploymentRelatedMachineMapper BOLDeploymentRelatedMachineMapperMock { get; set; } = new BOLDeploymentRelatedMachineMapper();

		public IBOLEventMapper BOLEventMapperMock { get; set; } = new BOLEventMapper();

		public IBOLEventRelatedDocumentMapper BOLEventRelatedDocumentMapperMock { get; set; } = new BOLEventRelatedDocumentMapper();

		public IBOLExtensionConfigurationMapper BOLExtensionConfigurationMapperMock { get; set; } = new BOLExtensionConfigurationMapper();

		public IBOLFeedMapper BOLFeedMapperMock { get; set; } = new BOLFeedMapper();

		public IBOLInterruptionMapper BOLInterruptionMapperMock { get; set; } = new BOLInterruptionMapper();

		public IBOLInvitationMapper BOLInvitationMapperMock { get; set; } = new BOLInvitationMapper();

		public IBOLKeyAllocationMapper BOLKeyAllocationMapperMock { get; set; } = new BOLKeyAllocationMapper();

		public IBOLLibraryVariableSetMapper BOLLibraryVariableSetMapperMock { get; set; } = new BOLLibraryVariableSetMapper();

		public IBOLLifecycleMapper BOLLifecycleMapperMock { get; set; } = new BOLLifecycleMapper();

		public IBOLMachineMapper BOLMachineMapperMock { get; set; } = new BOLMachineMapper();

		public IBOLMachinePolicyMapper BOLMachinePolicyMapperMock { get; set; } = new BOLMachinePolicyMapper();

		public IBOLMutexMapper BOLMutexMapperMock { get; set; } = new BOLMutexMapper();

		public IBOLNuGetPackageMapper BOLNuGetPackageMapperMock { get; set; } = new BOLNuGetPackageMapper();

		public IBOLOctopusServerNodeMapper BOLOctopusServerNodeMapperMock { get; set; } = new BOLOctopusServerNodeMapper();

		public IBOLProjectMapper BOLProjectMapperMock { get; set; } = new BOLProjectMapper();

		public IBOLProjectGroupMapper BOLProjectGroupMapperMock { get; set; } = new BOLProjectGroupMapper();

		public IBOLProjectTriggerMapper BOLProjectTriggerMapperMock { get; set; } = new BOLProjectTriggerMapper();

		public IBOLProxyMapper BOLProxyMapperMock { get; set; } = new BOLProxyMapper();

		public IBOLReleaseMapper BOLReleaseMapperMock { get; set; } = new BOLReleaseMapper();

		public IBOLSchemaVersionsMapper BOLSchemaVersionsMapperMock { get; set; } = new BOLSchemaVersionsMapper();

		public IBOLServerTaskMapper BOLServerTaskMapperMock { get; set; } = new BOLServerTaskMapper();

		public IBOLSubscriptionMapper BOLSubscriptionMapperMock { get; set; } = new BOLSubscriptionMapper();

		public IBOLTagSetMapper BOLTagSetMapperMock { get; set; } = new BOLTagSetMapper();

		public IBOLTeamMapper BOLTeamMapperMock { get; set; } = new BOLTeamMapper();

		public IBOLTenantMapper BOLTenantMapperMock { get; set; } = new BOLTenantMapper();

		public IBOLTenantVariableMapper BOLTenantVariableMapperMock { get; set; } = new BOLTenantVariableMapper();

		public IBOLUserMapper BOLUserMapperMock { get; set; } = new BOLUserMapper();

		public IBOLUserRoleMapper BOLUserRoleMapperMock { get; set; } = new BOLUserRoleMapper();

		public IBOLVariableSetMapper BOLVariableSetMapperMock { get; set; } = new BOLVariableSetMapper();

		public IBOLWorkerMapper BOLWorkerMapperMock { get; set; } = new BOLWorkerMapper();

		public IBOLWorkerPoolMapper BOLWorkerPoolMapperMock { get; set; } = new BOLWorkerPoolMapper();

		public IBOLWorkerTaskLeaseMapper BOLWorkerTaskLeaseMapperMock { get; set; } = new BOLWorkerTaskLeaseMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>906b1c8ab675da33fc72315220155d2e</Hash>
</Codenesium>*/