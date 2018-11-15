using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                              mock.DALMapperMockFactory.DALTeamMapperMock);

			List<ApiTeamServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var record = new Team();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                              mock.DALMapperMockFactory.DALTeamMapperMock);

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
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                              mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiTeamServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var model = new ApiTeamServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Team>())).Returns(Task.FromResult(new Team()));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                              mock.DALMapperMockFactory.DALTeamMapperMock);

			CreateResponse<ApiTeamServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeamServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Team>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var model = new ApiTeamServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Team>())).Returns(Task.FromResult(new Team()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Team()));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                              mock.DALMapperMockFactory.DALTeamMapperMock);

			UpdateResponse<ApiTeamServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeamServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Team>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var model = new ApiTeamServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                              mock.DALMapperMockFactory.DALTeamMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ITeamRepository>();
			var record = new Team();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new TeamService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                              mock.DALMapperMockFactory.DALTeamMapperMock);

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
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                              mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiTeamServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>eefef0fe7aa81461ea0ed30173f5fcff</Hash>
</Codenesium>*/