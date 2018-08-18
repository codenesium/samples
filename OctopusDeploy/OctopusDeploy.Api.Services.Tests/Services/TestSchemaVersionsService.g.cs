using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaVersions")]
	[Trait("Area", "Services")]
	public partial class SchemaVersionsServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISchemaVersionsRepository>();
			var records = new List<SchemaVersions>();
			records.Add(new SchemaVersions());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SchemaVersionsService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SchemaVersionsModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSchemaVersionsMapperMock,
			                                        mock.DALMapperMockFactory.DALSchemaVersionsMapperMock);

			List<ApiSchemaVersionsResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISchemaVersionsRepository>();
			var record = new SchemaVersions();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SchemaVersionsService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SchemaVersionsModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSchemaVersionsMapperMock,
			                                        mock.DALMapperMockFactory.DALSchemaVersionsMapperMock);

			ApiSchemaVersionsResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISchemaVersionsRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SchemaVersions>(null));
			var service = new SchemaVersionsService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SchemaVersionsModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSchemaVersionsMapperMock,
			                                        mock.DALMapperMockFactory.DALSchemaVersionsMapperMock);

			ApiSchemaVersionsResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISchemaVersionsRepository>();
			var model = new ApiSchemaVersionsRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaVersions>())).Returns(Task.FromResult(new SchemaVersions()));
			var service = new SchemaVersionsService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SchemaVersionsModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSchemaVersionsMapperMock,
			                                        mock.DALMapperMockFactory.DALSchemaVersionsMapperMock);

			CreateResponse<ApiSchemaVersionsResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SchemaVersionsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaVersionsRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SchemaVersions>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISchemaVersionsRepository>();
			var model = new ApiSchemaVersionsRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaVersions>())).Returns(Task.FromResult(new SchemaVersions()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaVersions()));
			var service = new SchemaVersionsService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SchemaVersionsModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSchemaVersionsMapperMock,
			                                        mock.DALMapperMockFactory.DALSchemaVersionsMapperMock);

			UpdateResponse<ApiSchemaVersionsResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SchemaVersionsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaVersionsRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SchemaVersions>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISchemaVersionsRepository>();
			var model = new ApiSchemaVersionsRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SchemaVersionsService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SchemaVersionsModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSchemaVersionsMapperMock,
			                                        mock.DALMapperMockFactory.DALSchemaVersionsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SchemaVersionsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>3e040af3c83f01f56867b057cd6a35d0</Hash>
</Codenesium>*/