using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                        List<ApiDocumentResponseModel> response = await service.All();

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

                        ApiDocumentResponseModel response = await service.Get(default (Guid));

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

                        ApiDocumentResponseModel response = await service.Get(default (Guid));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<Guid>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IDocumentRepository>();
                        var model = new ApiDocumentRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Document>())).Returns(Task.FromResult(new Document()));
                        var service = new DocumentService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLDocumentMapperMock,
                                                          mock.DALMapperMockFactory.DALDocumentMapperMock);

                        CreateResponse<ApiDocumentResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDocumentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Document>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IDocumentRepository>();
                        var model = new ApiDocumentRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Document>())).Returns(Task.FromResult(new Document()));
                        var service = new DocumentService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLDocumentMapperMock,
                                                          mock.DALMapperMockFactory.DALDocumentMapperMock);

                        ActionResponse response = await service.Update(default (Guid), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<Guid>(), It.IsAny<ApiDocumentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Document>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IDocumentRepository>();
                        var model = new ApiDocumentRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(Task.CompletedTask);
                        var service = new DocumentService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLDocumentMapperMock,
                                                          mock.DALMapperMockFactory.DALDocumentMapperMock);

                        ActionResponse response = await service.Delete(default (Guid));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<Guid>()));
                        mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<Guid>()));
                }

                [Fact]
                public async void ByFileNameRevision_Exists()
                {
                        var mock = new ServiceMockFacade<IDocumentRepository>();
                        var records = new List<Document>();
                        records.Add(new Document());
                        mock.RepositoryMock.Setup(x => x.ByFileNameRevision(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new DocumentService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLDocumentMapperMock,
                                                          mock.DALMapperMockFactory.DALDocumentMapperMock);

                        List<ApiDocumentResponseModel> response = await service.ByFileNameRevision(default (string), default (string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByFileNameRevision(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void ByFileNameRevision_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IDocumentRepository>();
                        mock.RepositoryMock.Setup(x => x.ByFileNameRevision(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<List<Document>>(new List<Document>()));
                        var service = new DocumentService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.DocumentModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLDocumentMapperMock,
                                                          mock.DALMapperMockFactory.DALDocumentMapperMock);

                        List<ApiDocumentResponseModel> response = await service.ByFileNameRevision(default (string), default (string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByFileNameRevision(It.IsAny<string>(), It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>b0f6b4785419d21c246e159428c7237c</Hash>
</Codenesium>*/