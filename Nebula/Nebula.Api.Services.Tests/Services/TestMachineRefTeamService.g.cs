using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "MachineRefTeam")]
	[Trait("Area", "Services")]
	public partial class MachineRefTeamServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
			var records = new List<MachineRefTeam>();
			records.Add(new MachineRefTeam());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new MachineRefTeamService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			List<ApiMachineRefTeamServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
			var record = new MachineRefTeam();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new MachineRefTeamService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ApiMachineRefTeamServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<MachineRefTeam>(null));
			var service = new MachineRefTeamService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ApiMachineRefTeamServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
			var model = new ApiMachineRefTeamServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<MachineRefTeam>())).Returns(Task.FromResult(new MachineRefTeam()));
			var service = new MachineRefTeamService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			CreateResponse<ApiMachineRefTeamServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRefTeamServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<MachineRefTeam>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineRefTeamCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
			var model = new ApiMachineRefTeamServerRequestModel();
			var validatorMock = new Mock<IApiMachineRefTeamServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRefTeamServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new MachineRefTeamService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			CreateResponse<ApiMachineRefTeamServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRefTeamServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineRefTeamCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
			var model = new ApiMachineRefTeamServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<MachineRefTeam>())).Returns(Task.FromResult(new MachineRefTeam()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new MachineRefTeam()));
			var service = new MachineRefTeamService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			UpdateResponse<ApiMachineRefTeamServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<MachineRefTeam>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineRefTeamUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
			var model = new ApiMachineRefTeamServerRequestModel();
			var validatorMock = new Mock<IApiMachineRefTeamServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new MachineRefTeam()));
			var service = new MachineRefTeamService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			UpdateResponse<ApiMachineRefTeamServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineRefTeamUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
			var model = new ApiMachineRefTeamServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new MachineRefTeamService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineRefTeamDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
			var model = new ApiMachineRefTeamServerRequestModel();
			var validatorMock = new Mock<IApiMachineRefTeamServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new MachineRefTeamService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<MachineRefTeamDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>27c6b88f2adbcfc7ecbf4c2ba4806960</Hash>
</Codenesium>*/