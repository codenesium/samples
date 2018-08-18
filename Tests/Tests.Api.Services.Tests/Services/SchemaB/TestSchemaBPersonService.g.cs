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
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "Services")]
	public partial class SchemaBPersonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var records = new List<SchemaBPerson>();
			records.Add(new SchemaBPerson());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                       mock.DALMapperMockFactory.DALPersonRefMapperMock);

			List<ApiSchemaBPersonResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var record = new SchemaBPerson();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                       mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ApiSchemaBPersonResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SchemaBPerson>(null));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                       mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ApiSchemaBPersonResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var model = new ApiSchemaBPersonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaBPerson>())).Returns(Task.FromResult(new SchemaBPerson()));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                       mock.DALMapperMockFactory.DALPersonRefMapperMock);

			CreateResponse<ApiSchemaBPersonResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSchemaBPersonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SchemaBPerson>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var model = new ApiSchemaBPersonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SchemaBPerson>())).Returns(Task.FromResult(new SchemaBPerson()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaBPerson()));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                       mock.DALMapperMockFactory.DALPersonRefMapperMock);

			UpdateResponse<ApiSchemaBPersonResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSchemaBPersonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SchemaBPerson>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var model = new ApiSchemaBPersonRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                       mock.DALMapperMockFactory.DALPersonRefMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void PersonRefs_Exists()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			var records = new List<PersonRef>();
			records.Add(new PersonRef());
			mock.RepositoryMock.Setup(x => x.PersonRefs(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                       mock.DALMapperMockFactory.DALPersonRefMapperMock);

			List<ApiPersonRefResponseModel> response = await service.PersonRefs(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PersonRefs(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PersonRefs_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISchemaBPersonRepository>();
			mock.RepositoryMock.Setup(x => x.PersonRefs(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PersonRef>>(new List<PersonRef>()));
			var service = new SchemaBPersonService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SchemaBPersonModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLSchemaBPersonMapperMock,
			                                       mock.DALMapperMockFactory.DALSchemaBPersonMapperMock,
			                                       mock.BOLMapperMockFactory.BOLPersonRefMapperMock,
			                                       mock.DALMapperMockFactory.DALPersonRefMapperMock);

			List<ApiPersonRefResponseModel> response = await service.PersonRefs(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PersonRefs(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>590914e6518a7fe78cb2eab4fe698f0c</Hash>
</Codenesium>*/