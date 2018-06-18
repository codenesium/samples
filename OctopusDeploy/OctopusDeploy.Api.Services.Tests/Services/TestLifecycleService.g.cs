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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Lifecycle")]
        [Trait("Area", "Services")]
        public partial class LifecycleServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        var records = new List<Lifecycle>();
                        records.Add(new Lifecycle());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        List<ApiLifecycleResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        var record = new Lifecycle();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        ApiLifecycleResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(null));
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        ApiLifecycleResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        var model = new ApiLifecycleRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Lifecycle>())).Returns(Task.FromResult(new Lifecycle()));
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        CreateResponse<ApiLifecycleResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLifecycleRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Lifecycle>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        var model = new ApiLifecycleRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Lifecycle>())).Returns(Task.FromResult(new Lifecycle()));
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiLifecycleRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Lifecycle>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        var model = new ApiLifecycleRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Exists()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        var record = new Lifecycle();

                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        ApiLifecycleResponseModel response = await service.GetName(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Lifecycle>(null));
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        ApiLifecycleResponseModel response = await service.GetName(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetDataVersion_Exists()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        var records = new List<Lifecycle>();
                        records.Add(new Lifecycle());
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult(records));
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        List<ApiLifecycleResponseModel> response = await service.GetDataVersion(default (byte[]));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }

                [Fact]
                public async void GetDataVersion_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ILifecycleRepository>();
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult<List<Lifecycle>>(new List<Lifecycle>()));
                        var service = new LifecycleService(mock.LoggerMock.Object,
                                                           mock.RepositoryMock.Object,
                                                           mock.ModelValidatorMockFactory.LifecycleModelValidatorMock.Object,
                                                           mock.BOLMapperMockFactory.BOLLifecycleMapperMock,
                                                           mock.DALMapperMockFactory.DALLifecycleMapperMock);

                        List<ApiLifecycleResponseModel> response = await service.GetDataVersion(default (byte[]));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }
        }
}

/*<Codenesium>
    <Hash>c5148b72b3193dfd48284539d52b092a</Hash>
</Codenesium>*/