using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "File")]
        [Trait("Area", "Services")]
        public partial class FileServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IFileRepository>();
                        var records = new List<File>();
                        records.Add(new File());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new FileService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                      mock.DALMapperMockFactory.DALFileMapperMock);

                        List<ApiFileResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IFileRepository>();
                        var record = new File();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new FileService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                      mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiFileResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IFileRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<File>(null));
                        var service = new FileService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                      mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiFileResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IFileRepository>();
                        var model = new ApiFileRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<File>())).Returns(Task.FromResult(new File()));
                        var service = new FileService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                      mock.DALMapperMockFactory.DALFileMapperMock);

                        CreateResponse<ApiFileResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.FileModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFileRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<File>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IFileRepository>();
                        var model = new ApiFileRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<File>())).Returns(Task.FromResult(new File()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));
                        var service = new FileService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                      mock.DALMapperMockFactory.DALFileMapperMock);

                        UpdateResponse<ApiFileResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.FileModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<File>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IFileRepository>();
                        var model = new ApiFileRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new FileService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                      mock.DALMapperMockFactory.DALFileMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.FileModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>4229ad2a0caf8825f1c94817ce0c7c3f</Hash>
</Codenesium>*/