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
		public Mock<IApiChainServerRequestModelValidator> ChainModelValidatorMock { get; set; } = new Mock<IApiChainServerRequestModelValidator>();

		public Mock<IApiChainStatusServerRequestModelValidator> ChainStatusModelValidatorMock { get; set; } = new Mock<IApiChainStatusServerRequestModelValidator>();

		public Mock<IApiClaspServerRequestModelValidator> ClaspModelValidatorMock { get; set; } = new Mock<IApiClaspServerRequestModelValidator>();

		public Mock<IApiLinkServerRequestModelValidator> LinkModelValidatorMock { get; set; } = new Mock<IApiLinkServerRequestModelValidator>();

		public Mock<IApiLinkLogServerRequestModelValidator> LinkLogModelValidatorMock { get; set; } = new Mock<IApiLinkLogServerRequestModelValidator>();

		public Mock<IApiLinkStatusServerRequestModelValidator> LinkStatusModelValidatorMock { get; set; } = new Mock<IApiLinkStatusServerRequestModelValidator>();

		public Mock<IApiMachineServerRequestModelValidator> MachineModelValidatorMock { get; set; } = new Mock<IApiMachineServerRequestModelValidator>();

		public Mock<IApiOrganizationServerRequestModelValidator> OrganizationModelValidatorMock { get; set; } = new Mock<IApiOrganizationServerRequestModelValidator>();

		public Mock<IApiTeamServerRequestModelValidator> TeamModelValidatorMock { get; set; } = new Mock<IApiTeamServerRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.ChainModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ChainStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiChainStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ChainStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.ClaspModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiClaspServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClaspModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiClaspServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.ClaspModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkLogModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkLogServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkLogModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkLogServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkLogModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.LinkStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.LinkStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.MachineModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMachineServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.MachineModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.OrganizationModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOrganizationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OrganizationModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOrganizationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.OrganizationModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TeamModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeamServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeamModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeamServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeamModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>ce2527891588a65a3ba395ca8fb8c19f</Hash>
</Codenesium>*/