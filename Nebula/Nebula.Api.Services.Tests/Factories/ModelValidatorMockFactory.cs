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

		public Mock<IApiChainStatusRequestModelValidator> ChainStatusModelValidatorMock { get; set; } = new Mock<IApiChainStatusRequestModelValidator>();

		public Mock<IApiClaspRequestModelValidator> ClaspModelValidatorMock { get; set; } = new Mock<IApiClaspRequestModelValidator>();

		public Mock<IApiLinkRequestModelValidator> LinkModelValidatorMock { get; set; } = new Mock<IApiLinkRequestModelValidator>();

		public Mock<IApiLinkLogRequestModelValidator> LinkLogModelValidatorMock { get; set; } = new Mock<IApiLinkLogRequestModelValidator>();

		public Mock<IApiLinkStatusRequestModelValidator> LinkStatusModelValidatorMock { get; set; } = new Mock<IApiLinkStatusRequestModelValidator>();

		public Mock<IApiMachineRequestModelValidator> MachineModelValidatorMock { get; set; } = new Mock<IApiMachineRequestModelValidator>();

		public Mock<IApiMachineRefTeamRequestModelValidator> MachineRefTeamModelValidatorMock { get; set; } = new Mock<IApiMachineRefTeamRequestModelValidator>();

		public Mock<IApiOrganizationRequestModelValidator> OrganizationModelValidatorMock { get; set; } = new Mock<IApiOrganizationRequestModelValidator>();

		public Mock<IApiTeamRequestModelValidator> TeamModelValidatorMock { get; set; } = new Mock<IApiTeamRequestModelValidator>();

		public Mock<IApiVersionInfoRequestModelValidator> VersionInfoModelValidatorMock { get; set; } = new Mock<IApiVersionInfoRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.ChainModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ChainStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiChainStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ClaspModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiClaspRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClaspModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClaspRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClaspModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkLogModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkLogRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkLogModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkLogRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkLogModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MachineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MachineRefTeamModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineRefTeamModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineRefTeamModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.OrganizationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOrganizationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OrganizationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOrganizationRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OrganizationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

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
    <Hash>f9fbc192ebe867472ba7f941ef60fbf9</Hash>
</Codenesium>*/