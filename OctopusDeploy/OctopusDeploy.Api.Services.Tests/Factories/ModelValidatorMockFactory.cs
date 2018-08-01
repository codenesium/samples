using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiAccountRequestModelValidator> AccountModelValidatorMock { get; set; } = new Mock<IApiAccountRequestModelValidator>();

		public Mock<IApiActionTemplateRequestModelValidator> ActionTemplateModelValidatorMock { get; set; } = new Mock<IApiActionTemplateRequestModelValidator>();

		public Mock<IApiActionTemplateVersionRequestModelValidator> ActionTemplateVersionModelValidatorMock { get; set; } = new Mock<IApiActionTemplateVersionRequestModelValidator>();

		public Mock<IApiApiKeyRequestModelValidator> ApiKeyModelValidatorMock { get; set; } = new Mock<IApiApiKeyRequestModelValidator>();

		public Mock<IApiArtifactRequestModelValidator> ArtifactModelValidatorMock { get; set; } = new Mock<IApiArtifactRequestModelValidator>();

		public Mock<IApiCertificateRequestModelValidator> CertificateModelValidatorMock { get; set; } = new Mock<IApiCertificateRequestModelValidator>();

		public Mock<IApiChannelRequestModelValidator> ChannelModelValidatorMock { get; set; } = new Mock<IApiChannelRequestModelValidator>();

		public Mock<IApiCommunityActionTemplateRequestModelValidator> CommunityActionTemplateModelValidatorMock { get; set; } = new Mock<IApiCommunityActionTemplateRequestModelValidator>();

		public Mock<IApiConfigurationRequestModelValidator> ConfigurationModelValidatorMock { get; set; } = new Mock<IApiConfigurationRequestModelValidator>();

		public Mock<IApiDashboardConfigurationRequestModelValidator> DashboardConfigurationModelValidatorMock { get; set; } = new Mock<IApiDashboardConfigurationRequestModelValidator>();

		public Mock<IApiDeploymentRequestModelValidator> DeploymentModelValidatorMock { get; set; } = new Mock<IApiDeploymentRequestModelValidator>();

		public Mock<IApiDeploymentEnvironmentRequestModelValidator> DeploymentEnvironmentModelValidatorMock { get; set; } = new Mock<IApiDeploymentEnvironmentRequestModelValidator>();

		public Mock<IApiDeploymentHistoryRequestModelValidator> DeploymentHistoryModelValidatorMock { get; set; } = new Mock<IApiDeploymentHistoryRequestModelValidator>();

		public Mock<IApiDeploymentProcessRequestModelValidator> DeploymentProcessModelValidatorMock { get; set; } = new Mock<IApiDeploymentProcessRequestModelValidator>();

		public Mock<IApiDeploymentRelatedMachineRequestModelValidator> DeploymentRelatedMachineModelValidatorMock { get; set; } = new Mock<IApiDeploymentRelatedMachineRequestModelValidator>();

		public Mock<IApiEventRequestModelValidator> EventModelValidatorMock { get; set; } = new Mock<IApiEventRequestModelValidator>();

		public Mock<IApiEventRelatedDocumentRequestModelValidator> EventRelatedDocumentModelValidatorMock { get; set; } = new Mock<IApiEventRelatedDocumentRequestModelValidator>();

		public Mock<IApiExtensionConfigurationRequestModelValidator> ExtensionConfigurationModelValidatorMock { get; set; } = new Mock<IApiExtensionConfigurationRequestModelValidator>();

		public Mock<IApiFeedRequestModelValidator> FeedModelValidatorMock { get; set; } = new Mock<IApiFeedRequestModelValidator>();

		public Mock<IApiInterruptionRequestModelValidator> InterruptionModelValidatorMock { get; set; } = new Mock<IApiInterruptionRequestModelValidator>();

		public Mock<IApiInvitationRequestModelValidator> InvitationModelValidatorMock { get; set; } = new Mock<IApiInvitationRequestModelValidator>();

		public Mock<IApiKeyAllocationRequestModelValidator> KeyAllocationModelValidatorMock { get; set; } = new Mock<IApiKeyAllocationRequestModelValidator>();

		public Mock<IApiLibraryVariableSetRequestModelValidator> LibraryVariableSetModelValidatorMock { get; set; } = new Mock<IApiLibraryVariableSetRequestModelValidator>();

		public Mock<IApiLifecycleRequestModelValidator> LifecycleModelValidatorMock { get; set; } = new Mock<IApiLifecycleRequestModelValidator>();

		public Mock<IApiMachineRequestModelValidator> MachineModelValidatorMock { get; set; } = new Mock<IApiMachineRequestModelValidator>();

		public Mock<IApiMachinePolicyRequestModelValidator> MachinePolicyModelValidatorMock { get; set; } = new Mock<IApiMachinePolicyRequestModelValidator>();

		public Mock<IApiMutexRequestModelValidator> MutexModelValidatorMock { get; set; } = new Mock<IApiMutexRequestModelValidator>();

		public Mock<IApiNuGetPackageRequestModelValidator> NuGetPackageModelValidatorMock { get; set; } = new Mock<IApiNuGetPackageRequestModelValidator>();

		public Mock<IApiOctopusServerNodeRequestModelValidator> OctopusServerNodeModelValidatorMock { get; set; } = new Mock<IApiOctopusServerNodeRequestModelValidator>();

		public Mock<IApiProjectRequestModelValidator> ProjectModelValidatorMock { get; set; } = new Mock<IApiProjectRequestModelValidator>();

		public Mock<IApiProjectGroupRequestModelValidator> ProjectGroupModelValidatorMock { get; set; } = new Mock<IApiProjectGroupRequestModelValidator>();

		public Mock<IApiProjectTriggerRequestModelValidator> ProjectTriggerModelValidatorMock { get; set; } = new Mock<IApiProjectTriggerRequestModelValidator>();

		public Mock<IApiProxyRequestModelValidator> ProxyModelValidatorMock { get; set; } = new Mock<IApiProxyRequestModelValidator>();

		public Mock<IApiReleaseRequestModelValidator> ReleaseModelValidatorMock { get; set; } = new Mock<IApiReleaseRequestModelValidator>();

		public Mock<IApiSchemaVersionsRequestModelValidator> SchemaVersionsModelValidatorMock { get; set; } = new Mock<IApiSchemaVersionsRequestModelValidator>();

		public Mock<IApiServerTaskRequestModelValidator> ServerTaskModelValidatorMock { get; set; } = new Mock<IApiServerTaskRequestModelValidator>();

		public Mock<IApiSubscriptionRequestModelValidator> SubscriptionModelValidatorMock { get; set; } = new Mock<IApiSubscriptionRequestModelValidator>();

		public Mock<IApiTagSetRequestModelValidator> TagSetModelValidatorMock { get; set; } = new Mock<IApiTagSetRequestModelValidator>();

		public Mock<IApiTeamRequestModelValidator> TeamModelValidatorMock { get; set; } = new Mock<IApiTeamRequestModelValidator>();

		public Mock<IApiTenantRequestModelValidator> TenantModelValidatorMock { get; set; } = new Mock<IApiTenantRequestModelValidator>();

		public Mock<IApiTenantVariableRequestModelValidator> TenantVariableModelValidatorMock { get; set; } = new Mock<IApiTenantVariableRequestModelValidator>();

		public Mock<IApiUserRequestModelValidator> UserModelValidatorMock { get; set; } = new Mock<IApiUserRequestModelValidator>();

		public Mock<IApiUserRoleRequestModelValidator> UserRoleModelValidatorMock { get; set; } = new Mock<IApiUserRoleRequestModelValidator>();

		public Mock<IApiVariableSetRequestModelValidator> VariableSetModelValidatorMock { get; set; } = new Mock<IApiVariableSetRequestModelValidator>();

		public Mock<IApiWorkerRequestModelValidator> WorkerModelValidatorMock { get; set; } = new Mock<IApiWorkerRequestModelValidator>();

		public Mock<IApiWorkerPoolRequestModelValidator> WorkerPoolModelValidatorMock { get; set; } = new Mock<IApiWorkerPoolRequestModelValidator>();

		public Mock<IApiWorkerTaskLeaseRequestModelValidator> WorkerTaskLeaseModelValidatorMock { get; set; } = new Mock<IApiWorkerTaskLeaseRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AccountModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAccountRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AccountModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiAccountRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AccountModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ActionTemplateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiActionTemplateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ActionTemplateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiActionTemplateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ActionTemplateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ActionTemplateVersionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiActionTemplateVersionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ActionTemplateVersionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiActionTemplateVersionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ActionTemplateVersionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ApiKeyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiApiKeyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ApiKeyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiApiKeyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ApiKeyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ArtifactModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiArtifactRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ArtifactModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiArtifactRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ArtifactModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CertificateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCertificateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CertificateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCertificateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CertificateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ChannelModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiChannelRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChannelModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiChannelRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChannelModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.CommunityActionTemplateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCommunityActionTemplateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommunityActionTemplateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCommunityActionTemplateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.CommunityActionTemplateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ConfigurationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiConfigurationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ConfigurationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiConfigurationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ConfigurationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DashboardConfigurationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDashboardConfigurationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DashboardConfigurationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDashboardConfigurationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DashboardConfigurationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DeploymentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDeploymentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DeploymentEnvironmentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentEnvironmentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentEnvironmentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDeploymentEnvironmentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentEnvironmentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DeploymentHistoryModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentHistoryModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDeploymentHistoryRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentHistoryModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DeploymentProcessModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentProcessRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentProcessModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDeploymentProcessRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentProcessModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.DeploymentRelatedMachineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentRelatedMachineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentRelatedMachineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeploymentRelatedMachineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.DeploymentRelatedMachineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventRelatedDocumentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventRelatedDocumentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventRelatedDocumentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventRelatedDocumentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventRelatedDocumentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ExtensionConfigurationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiExtensionConfigurationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ExtensionConfigurationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiExtensionConfigurationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ExtensionConfigurationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.FeedModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFeedRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FeedModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiFeedRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FeedModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.InterruptionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiInterruptionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.InterruptionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiInterruptionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.InterruptionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.InvitationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiInvitationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.InvitationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiInvitationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.InvitationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.KeyAllocationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiKeyAllocationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.KeyAllocationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiKeyAllocationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.KeyAllocationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LibraryVariableSetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLibraryVariableSetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LibraryVariableSetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiLibraryVariableSetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LibraryVariableSetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LifecycleModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLifecycleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LifecycleModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiLifecycleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LifecycleModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MachineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MachinePolicyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMachinePolicyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachinePolicyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiMachinePolicyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachinePolicyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MutexModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMutexRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MutexModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiMutexRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MutexModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.NuGetPackageModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiNuGetPackageRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.NuGetPackageModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiNuGetPackageRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.NuGetPackageModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.OctopusServerNodeModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOctopusServerNodeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OctopusServerNodeModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiOctopusServerNodeRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OctopusServerNodeModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProjectModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProjectRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProjectModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiProjectRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProjectModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProjectGroupModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProjectGroupRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProjectGroupModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiProjectGroupRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProjectGroupModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProjectTriggerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProjectTriggerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProjectTriggerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiProjectTriggerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProjectTriggerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ProxyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProxyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProxyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiProxyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ProxyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ReleaseModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiReleaseRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ReleaseModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiReleaseRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ReleaseModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SchemaVersionsModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaVersionsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SchemaVersionsModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaVersionsRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SchemaVersionsModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ServerTaskModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiServerTaskRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ServerTaskModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiServerTaskRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ServerTaskModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SubscriptionModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSubscriptionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SubscriptionModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiSubscriptionRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SubscriptionModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TagSetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTagSetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagSetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiTagSetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TagSetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TeamModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeamRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeamModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiTeamRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeamModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TenantModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTenantRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TenantModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiTenantRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TenantModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TenantVariableModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTenantVariableRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TenantVariableModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiTenantVariableRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TenantVariableModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UserModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UserRoleModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserRoleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserRoleModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiUserRoleRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserRoleModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VariableSetModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVariableSetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VariableSetModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiVariableSetRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VariableSetModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.WorkerModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiWorkerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.WorkerModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiWorkerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.WorkerModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.WorkerPoolModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiWorkerPoolRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.WorkerPoolModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiWorkerPoolRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.WorkerPoolModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.WorkerTaskLeaseModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiWorkerTaskLeaseRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.WorkerTaskLeaseModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiWorkerTaskLeaseRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.WorkerTaskLeaseModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<string>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>c88d35a245de3cca743e89f5d5424fc1</Hash>
</Codenesium>*/