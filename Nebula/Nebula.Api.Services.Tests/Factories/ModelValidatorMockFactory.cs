using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiChainRequestModelValidator> ChainModelValidatorMock { get; set; } = new Mock<IApiChainRequestModelValidator>();

		public Mock<IApiChainStatuRequestModelValidator> ChainStatuModelValidatorMock { get; set; } = new Mock<IApiChainStatuRequestModelValidator>();

		public Mock<IApiClaspRequestModelValidator> ClaspModelValidatorMock { get; set; } = new Mock<IApiClaspRequestModelValidator>();

		public Mock<IApiLinkRequestModelValidator> LinkModelValidatorMock { get; set; } = new Mock<IApiLinkRequestModelValidator>();

		public Mock<IApiLinkLogRequestModelValidator> LinkLogModelValidatorMock { get; set; } = new Mock<IApiLinkLogRequestModelValidator>();

		public Mock<IApiLinkStatuRequestModelValidator> LinkStatuModelValidatorMock { get; set; } = new Mock<IApiLinkStatuRequestModelValidator>();

		public Mock<IApiMachineRequestModelValidator> MachineModelValidatorMock { get; set; } = new Mock<IApiMachineRequestModelValidator>();

		public Mock<IApiMachineRefTeamRequestModelValidator> MachineRefTeamModelValidatorMock { get; set; } = new Mock<IApiMachineRefTeamRequestModelValidator>();

		public Mock<IApiOrganizationRequestModelValidator> OrganizationModelValidatorMock { get; set; } = new Mock<IApiOrganizationRequestModelValidator>();

		public Mock<IApiSysdiagramRequestModelValidator> SysdiagramModelValidatorMock { get; set; } = new Mock<IApiSysdiagramRequestModelValidator>();

		public Mock<IApiTeamRequestModelValidator> TeamModelValidatorMock { get; set; } = new Mock<IApiTeamRequestModelValidator>();

		public Mock<IApiVersionInfoRequestModelValidator> VersionInfoModelValidatorMock { get; set; } = new Mock<IApiVersionInfoRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.ChainModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ChainStatuModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiChainStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainStatuModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainStatuModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ClaspModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiClaspRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClaspModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClaspRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClaspModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkLogModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkLogRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkLogModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkLogRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkLogModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkStatuModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkStatuModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkStatuRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkStatuModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MachineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MachineRefTeamModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineRefTeamModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineRefTeamModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.OrganizationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOrganizationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OrganizationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOrganizationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OrganizationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SysdiagramModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSysdiagramRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SysdiagramModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSysdiagramRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SysdiagramModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TeamModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeamRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeamModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeamRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeamModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VersionInfoModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VersionInfoModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<long>(), It.IsAny<ApiVersionInfoRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VersionInfoModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<long>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>e40cdd44b7ad990f70a3ca08393aa1c7</Hash>
</Codenesium>*/