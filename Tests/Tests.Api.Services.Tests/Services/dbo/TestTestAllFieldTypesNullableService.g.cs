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
	[Trait("Table", "TestAllFieldTypesNullable")]
	[Trait("Area", "Services")]
	public partial class TestAllFieldTypesNullableServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableRepository>();
			var records = new List<TestAllFieldTypesNullable>();
			records.Add(new TestAllFieldTypesNullable());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTestAllFieldTypesNullableMapperMock,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			List<ApiTestAllFieldTypesNullableResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableRepository>();
			var record = new TestAllFieldTypesNullable();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTestAllFieldTypesNullableMapperMock,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			ApiTestAllFieldTypesNullableResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TestAllFieldTypesNullable>(null));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTestAllFieldTypesNullableMapperMock,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			ApiTestAllFieldTypesNullableResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableRepository>();
			var model = new ApiTestAllFieldTypesNullableRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldTypesNullable>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTestAllFieldTypesNullableMapperMock,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			CreateResponse<ApiTestAllFieldTypesNullableResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TestAllFieldTypesNullable>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableRepository>();
			var model = new ApiTestAllFieldTypesNullableRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TestAllFieldTypesNullable>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TestAllFieldTypesNullable()));
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTestAllFieldTypesNullableMapperMock,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			UpdateResponse<ApiTestAllFieldTypesNullableResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTestAllFieldTypesNullableRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TestAllFieldTypesNullable>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITestAllFieldTypesNullableRepository>();
			var model = new ApiTestAllFieldTypesNullableRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TestAllFieldTypesNullableService(mock.LoggerMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTestAllFieldTypesNullableMapperMock,
			                                                   mock.DALMapperMockFactory.DALTestAllFieldTypesNullableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TestAllFieldTypesNullableModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>4e3c5c36bdd258f93e802b3c24e4d8a2</Hash>
</Codenesium>*/