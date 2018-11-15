using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Document")]
	[Trait("Area", "Services")]
	public partial class DocumentServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			var records = new List<Document>();
			records.Add(new Document());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			List<ApiDocumentServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			var record = new Document();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			ApiDocumentServerResponseModel response = await service.Get(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<Guid>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult<Document>(null));
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			ApiDocumentServerResponseModel response = await service.Get(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<Guid>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			var model = new ApiDocumentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Document>())).Returns(Task.FromResult(new Document()));
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			CreateResponse<ApiDocumentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDocumentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Document>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			var model = new ApiDocumentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Document>())).Returns(Task.FromResult(new Document()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(new Document()));
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			UpdateResponse<ApiDocumentServerResponseModel> response = await service.Update(default(Guid), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<Guid>(), It.IsAny<ApiDocumentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Document>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			var model = new ApiDocumentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(Task.CompletedTask);
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			ActionResponse response = await service.Delete(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<Guid>()));
			mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			var record = new Document();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			ApiDocumentServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Document>(null));
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			ApiDocumentServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByFileNameRevision_Exists()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			var records = new List<Document>();
			records.Add(new Document());
			mock.RepositoryMock.Setup(x => x.ByFileNameRevision(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			List<ApiDocumentServerResponseModel> response = await service.ByFileNameRevision("test_value", "test_value");

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFileNameRevision(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByFileNameRevision_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDocumentRepository>();
			mock.RepositoryMock.Setup(x => x.ByFileNameRevision(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Document>>(new List<Document>()));
			var service = new DocumentService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLDocumentMapperMock,
			                                  mock.DALMapperMockFactory.DALDocumentMapperMock);

			List<ApiDocumentServerResponseModel> response = await service.ByFileNameRevision("test_value", "test_value");

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByFileNameRevision(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c96269f58936bc412bba7049aee48940</Hash>
</Codenesium>*/