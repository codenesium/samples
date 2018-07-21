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
        [Trait("Table", "Bucket")]
        [Trait("Area", "Services")]
        public partial class BucketServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        var records = new List<Bucket>();
                        records.Add(new Bucket());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        List<ApiBucketResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        var record = new Bucket();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiBucketResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Bucket>(null));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiBucketResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        var model = new ApiBucketRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Bucket>())).Returns(Task.FromResult(new Bucket()));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        CreateResponse<ApiBucketResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBucketRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Bucket>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        var model = new ApiBucketRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Bucket>())).Returns(Task.FromResult(new Bucket()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        UpdateResponse<ApiBucketResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBucketRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Bucket>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        var model = new ApiBucketRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByExternalId_Exists()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        var record = new Bucket();
                        mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult(record));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiBucketResponseModel response = await service.ByExternalId(default(Guid));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
                }

                [Fact]
                public async void ByExternalId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(null));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiBucketResponseModel response = await service.ByExternalId(default(Guid));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        var record = new Bucket();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiBucketResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Bucket>(null));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        ApiBucketResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void Files_Exists()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        var records = new List<File>();
                        records.Add(new File());
                        mock.RepositoryMock.Setup(x => x.Files(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        List<ApiFileResponseModel> response = await service.Files(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Files(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Files_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IBucketRepository>();
                        mock.RepositoryMock.Setup(x => x.Files(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<File>>(new List<File>()));
                        var service = new BucketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLBucketMapperMock,
                                                        mock.DALMapperMockFactory.DALBucketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLFileMapperMock,
                                                        mock.DALMapperMockFactory.DALFileMapperMock);

                        List<ApiFileResponseModel> response = await service.Files(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Files(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>364ea2f704fb52b065a3a114354ffb38</Hash>
</Codenesium>*/