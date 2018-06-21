using Moq;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services.Tests
{
        public class DALMapperMockFactory
        {
                public IDALAccountMapper DALAccountMapperMock { get; set; } = new DALAccountMapper();

                public IDALActionTemplateMapper DALActionTemplateMapperMock { get; set; } = new DALActionTemplateMapper();

                public IDALActionTemplateVersionMapper DALActionTemplateVersionMapperMock { get; set; } = new DALActionTemplateVersionMapper();

                public IDALApiKeyMapper DALApiKeyMapperMock { get; set; } = new DALApiKeyMapper();

                public IDALArtifactMapper DALArtifactMapperMock { get; set; } = new DALArtifactMapper();

                public IDALCertificateMapper DALCertificateMapperMock { get; set; } = new DALCertificateMapper();

                public IDALChannelMapper DALChannelMapperMock { get; set; } = new DALChannelMapper();

                public IDALCommunityActionTemplateMapper DALCommunityActionTemplateMapperMock { get; set; } = new DALCommunityActionTemplateMapper();

                public IDALConfigurationMapper DALConfigurationMapperMock { get; set; } = new DALConfigurationMapper();

                public IDALDashboardConfigurationMapper DALDashboardConfigurationMapperMock { get; set; } = new DALDashboardConfigurationMapper();

                public IDALDeploymentMapper DALDeploymentMapperMock { get; set; } = new DALDeploymentMapper();

                public IDALDeploymentEnvironmentMapper DALDeploymentEnvironmentMapperMock { get; set; } = new DALDeploymentEnvironmentMapper();

                public IDALDeploymentHistoryMapper DALDeploymentHistoryMapperMock { get; set; } = new DALDeploymentHistoryMapper();

                public IDALDeploymentProcessMapper DALDeploymentProcessMapperMock { get; set; } = new DALDeploymentProcessMapper();

                public IDALDeploymentRelatedMachineMapper DALDeploymentRelatedMachineMapperMock { get; set; } = new DALDeploymentRelatedMachineMapper();

                public IDALEventMapper DALEventMapperMock { get; set; } = new DALEventMapper();

                public IDALEventRelatedDocumentMapper DALEventRelatedDocumentMapperMock { get; set; } = new DALEventRelatedDocumentMapper();

                public IDALExtensionConfigurationMapper DALExtensionConfigurationMapperMock { get; set; } = new DALExtensionConfigurationMapper();

                public IDALFeedMapper DALFeedMapperMock { get; set; } = new DALFeedMapper();

                public IDALInterruptionMapper DALInterruptionMapperMock { get; set; } = new DALInterruptionMapper();

                public IDALInvitationMapper DALInvitationMapperMock { get; set; } = new DALInvitationMapper();

                public IDALKeyAllocationMapper DALKeyAllocationMapperMock { get; set; } = new DALKeyAllocationMapper();

                public IDALLibraryVariableSetMapper DALLibraryVariableSetMapperMock { get; set; } = new DALLibraryVariableSetMapper();

                public IDALLifecycleMapper DALLifecycleMapperMock { get; set; } = new DALLifecycleMapper();

                public IDALMachineMapper DALMachineMapperMock { get; set; } = new DALMachineMapper();

                public IDALMachinePolicyMapper DALMachinePolicyMapperMock { get; set; } = new DALMachinePolicyMapper();

                public IDALMutexMapper DALMutexMapperMock { get; set; } = new DALMutexMapper();

                public IDALNuGetPackageMapper DALNuGetPackageMapperMock { get; set; } = new DALNuGetPackageMapper();

                public IDALOctopusServerNodeMapper DALOctopusServerNodeMapperMock { get; set; } = new DALOctopusServerNodeMapper();

                public IDALProjectMapper DALProjectMapperMock { get; set; } = new DALProjectMapper();

                public IDALProjectGroupMapper DALProjectGroupMapperMock { get; set; } = new DALProjectGroupMapper();

                public IDALProjectTriggerMapper DALProjectTriggerMapperMock { get; set; } = new DALProjectTriggerMapper();

                public IDALProxyMapper DALProxyMapperMock { get; set; } = new DALProxyMapper();

                public IDALReleaseMapper DALReleaseMapperMock { get; set; } = new DALReleaseMapper();

                public IDALSchemaVersionsMapper DALSchemaVersionsMapperMock { get; set; } = new DALSchemaVersionsMapper();

                public IDALServerTaskMapper DALServerTaskMapperMock { get; set; } = new DALServerTaskMapper();

                public IDALSubscriptionMapper DALSubscriptionMapperMock { get; set; } = new DALSubscriptionMapper();

                public IDALTagSetMapper DALTagSetMapperMock { get; set; } = new DALTagSetMapper();

                public IDALTeamMapper DALTeamMapperMock { get; set; } = new DALTeamMapper();

                public IDALTenantMapper DALTenantMapperMock { get; set; } = new DALTenantMapper();

                public IDALTenantVariableMapper DALTenantVariableMapperMock { get; set; } = new DALTenantVariableMapper();

                public IDALUserMapper DALUserMapperMock { get; set; } = new DALUserMapper();

                public IDALUserRoleMapper DALUserRoleMapperMock { get; set; } = new DALUserRoleMapper();

                public IDALVariableSetMapper DALVariableSetMapperMock { get; set; } = new DALVariableSetMapper();

                public IDALWorkerMapper DALWorkerMapperMock { get; set; } = new DALWorkerMapper();

                public IDALWorkerPoolMapper DALWorkerPoolMapperMock { get; set; } = new DALWorkerPoolMapper();

                public IDALWorkerTaskLeaseMapper DALWorkerTaskLeaseMapperMock { get; set; } = new DALWorkerTaskLeaseMapper();

                public DALMapperMockFactory()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f185e122ff5d55e264ec7f80aae9eb39</Hash>
</Codenesium>*/