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
	[Trait("Table", "Person")]
	[Trait("Area", "Services")]
	public partial class PersonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var records = new List<Person>();
			records.Add(new Person());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiPersonResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var record = new Person();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiPersonResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiPersonResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var model = new ApiPersonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Person>())).Returns(Task.FromResult(new Person()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			CreateResponse<ApiPersonResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPersonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Person>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var model = new ApiPersonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Person>())).Returns(Task.FromResult(new Person()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			UpdateResponse<ApiPersonResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPersonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Person>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var model = new ApiPersonRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ColumnSameAsFKTables_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			var records = new List<ColumnSameAsFKTable>();
			records.Add(new ColumnSameAsFKTable());
			mock.RepositoryMock.Setup(x => x.ColumnSameAsFKTables(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiColumnSameAsFKTableResponseModel> response = await service.ColumnSameAsFKTables(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ColumnSameAsFKTables(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ColumnSameAsFKTables_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPersonRepository>();
			mock.RepositoryMock.Setup(x => x.ColumnSameAsFKTables(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ColumnSameAsFKTable>>(new List<ColumnSameAsFKTable>()));
			var service = new PersonService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.PersonModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLPersonMapperMock,
			                                mock.DALMapperMockFactory.DALPersonMapperMock,
			                                mock.BOLMapperMockFactory.BOLColumnSameAsFKTableMapperMock,
			                                mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiColumnSameAsFKTableResponseModel> response = await service.ColumnSameAsFKTables(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ColumnSameAsFKTables(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a8723619d286a81ac94ff069b2b5c9dd</Hash>
</Codenesium>*/