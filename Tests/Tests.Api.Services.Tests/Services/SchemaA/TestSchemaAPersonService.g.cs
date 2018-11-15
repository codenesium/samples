using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "Services")]
	public partial class SchemaAPersonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var records = new List<SchemaAPerson>();
			records.Add(new SchemaAPerson());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			List<ApiSchemaAPersonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var record = new SchemaAPerson();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			ApiSchemaAPersonServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SchemaAPerson>(null));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			ApiSchemaAPersonServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var model = new ApiSchemaAPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaAPerson>())).Returns(Task.FromResult(new SchemaAPerson()));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			CreateResponse<ApiSchemaAPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaAPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SchemaAPerson>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var model = new ApiSchemaAPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaAPerson>())).Returns(Task.FromResult(new SchemaAPerson()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaAPerson()));
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			UpdateResponse<ApiSchemaAPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaAPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SchemaAPerson>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISchemaAPersonRepository>();
			var model = new ApiSchemaAPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SchemaAPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaAPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaAPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SchemaAPersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5929bcd5651b99b5a0ee41b94c115c71</Hash>
</Codenesium>*/