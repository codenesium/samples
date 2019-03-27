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
	[Trait("Table", "Team")]
	[Trait("Area", "Services")]
	public partial class TeamServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var records = new List<Team>();
			records.Add(new Team());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			List<ApiTeamServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var record = new Team();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ApiTeamServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Team>(null));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ApiTeamServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var model = new ApiTeamServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Team>())).Returns(Task.FromResult(new Team()));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			CreateResponse<ApiTeamServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeamServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Team>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeamCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var model = new ApiTeamServerRequestModel();
			var validatorMock = new Mock<IApiTeamServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeamServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			CreateResponse<ApiTeamServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeamServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeamCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var model = new ApiTeamServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Team>())).Returns(Task.FromResult(new Team()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Team()));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			UpdateResponse<ApiTeamServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeamServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Team>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeamUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var model = new ApiTeamServerRequestModel();
			var validatorMock = new Mock<IApiTeamServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeamServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Team()));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			UpdateResponse<ApiTeamServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeamServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeamUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var model = new ApiTeamServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeamDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var model = new ApiTeamServerRequestModel();
			var validatorMock = new Mock<IApiTeamServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TeamDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var record = new Team();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ApiTeamServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Team>(null));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			ApiTeamServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ChainsByTeamId_Exists()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var records = new List<Chain>();
			records.Add(new Chain());
			mock.RepositoryMock.Setup(x => x.ChainsByTeamId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			List<ApiChainServerResponseModel> response = await service.ChainsByTeamId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ChainsByTeamId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ChainsByTeamId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			mock.RepositoryMock.Setup(x => x.ChainsByTeamId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Chain>>(new List<Chain>()));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			List<ApiChainServerResponseModel> response = await service.ChainsByTeamId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ChainsByTeamId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MachineRefTeamsByTeamId_Exists()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var records = new List<MachineRefTeam>();
			records.Add(new MachineRefTeam());
			mock.RepositoryMock.Setup(x => x.MachineRefTeamsByTeamId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			List<ApiMachineRefTeamServerResponseModel> response = await service.MachineRefTeamsByTeamId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.MachineRefTeamsByTeamId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void MachineRefTeamsByTeamId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			mock.RepositoryMock.Setup(x => x.MachineRefTeamsByTeamId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<MachineRefTeam>>(new List<MachineRefTeam>()));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTeamMapperMock,
			                              mock.DALMapperMockFactory.DALChainMapperMock,
			                              mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

			List<ApiMachineRefTeamServerResponseModel> response = await service.MachineRefTeamsByTeamId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.MachineRefTeamsByTeamId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>ff31b17cc7e5e41abd8a8eb3593f6327</Hash>
</Codenesium>*/