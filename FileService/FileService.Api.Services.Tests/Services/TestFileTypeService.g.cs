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
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "FileType")]
        [Trait("Area", "Services")]
        public partial class FileTypeServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IFileTypeRepository>();
                        var records = new List<FileType>();
                        records.Add(new FileType());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new FileTypeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
                                                          mock.DALMapperMockFactory.DALFileTypeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                          mock.DALMapperMockFactory.DALFileMapperMock);

                        List<ApiFileTypeResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IFileTypeRepository>();
                        var record = new FileType();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new FileTypeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
                                                          mock.DALMapperMockFactory.DALFileTypeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                          mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiFileTypeResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IFileTypeRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<FileType>(null));
                        var service = new FileTypeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
                                                          mock.DALMapperMockFactory.DALFileTypeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                          mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiFileTypeResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IFileTypeRepository>();
                        var model = new ApiFileTypeRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<FileType>())).Returns(Task.FromResult(new FileType()));
                        var service = new FileTypeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
                                                          mock.DALMapperMockFactory.DALFileTypeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                          mock.DALMapperMockFactory.DALFileMapperMock);

                        CreateResponse<ApiFileTypeResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFileTypeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<FileType>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IFileTypeRepository>();
                        var model = new ApiFileTypeRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<FileType>())).Returns(Task.FromResult(new FileType()));
                        var service = new FileTypeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
                                                          mock.DALMapperMockFactory.DALFileTypeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                          mock.DALMapperMockFactory.DALFileMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileTypeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<FileType>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IFileTypeRepository>();
                        var model = new ApiFileTypeRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new FileTypeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
                                                          mock.DALMapperMockFactory.DALFileTypeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                          mock.DALMapperMockFactory.DALFileMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void Files_Exists()
                {
                        var mock = new ServiceMockFacade<IFileTypeRepository>();
                        var records = new List<File>();
                        records.Add(new File());
                        mock.RepositoryMock.Setup(x => x.Files(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new FileTypeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
                                                          mock.DALMapperMockFactory.DALFileTypeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                          mock.DALMapperMockFactory.DALFileMapperMock);

                        List<ApiFileResponseModel> response = await service.Files(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Files(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Files_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IFileTypeRepository>();
                        mock.RepositoryMock.Setup(x => x.Files(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<File>>(new List<File>()));
                        var service = new FileTypeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
                                                          mock.DALMapperMockFactory.DALFileTypeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                          mock.DALMapperMockFactory.DALFileMapperMock);

                        List<ApiFileResponseModel> response = await service.Files(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Files(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>5e5c7647a8443226728cc12ab8d23928</Hash>
</Codenesium>*/