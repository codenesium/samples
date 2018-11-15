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
	[Trait("Table", "Organization")]
	[Trait("Area", "Services")]
	public partial class OrganizationServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			var records = new List<Organization>();
			records.Add(new Organization());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			List<ApiOrganizationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			var record = new Organization();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiOrganizationServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Organization>(null));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiOrganizationServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			var model = new ApiOrganizationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Organization>())).Returns(Task.FromResult(new Organization()));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			CreateResponse<ApiOrganizationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOrganizationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Organization>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			var model = new ApiOrganizationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Organization>())).Returns(Task.FromResult(new Organization()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			UpdateResponse<ApiOrganizationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOrganizationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Organization>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			var model = new ApiOrganizationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			var record = new Organization();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiOrganizationServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Organization>(null));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			ApiOrganizationServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void TeamsByOrganizationId_Exists()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			var records = new List<Team>();
			records.Add(new Team());
			mock.RepositoryMock.Setup(x => x.TeamsByOrganizationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			List<ApiTeamServerResponseModel> response = await service.TeamsByOrganizationId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TeamsByOrganizationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TeamsByOrganizationId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IOrganizationRepository>();
			mock.RepositoryMock.Setup(x => x.TeamsByOrganizationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Team>>(new List<Team>()));
			var service = new OrganizationService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.OrganizationModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLOrganizationMapperMock,
			                                      mock.DALMapperMockFactory.DALOrganizationMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
			                                      mock.DALMapperMockFactory.DALTeamMapperMock);

			List<ApiTeamServerResponseModel> response = await service.TeamsByOrganizationId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TeamsByOrganizationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>44ad72bf93e8e8c0b9c4a254a70c2e44</Hash>
</Codenesium>*/