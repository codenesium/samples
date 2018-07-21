using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SpaceFeature")]
        [Trait("Area", "Services")]
        public partial class SpaceFeatureServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
                        var records = new List<SpaceFeature>();
                        records.Add(new SpaceFeature());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SpaceFeatureService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                              mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        List<ApiSpaceFeatureResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
                        var record = new SpaceFeature();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new SpaceFeatureService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                              mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        ApiSpaceFeatureResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(null));
                        var service = new SpaceFeatureService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                              mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        ApiSpaceFeatureResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
                        var model = new ApiSpaceFeatureRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceFeature>())).Returns(Task.FromResult(new SpaceFeature()));
                        var service = new SpaceFeatureService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                              mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        CreateResponse<ApiSpaceFeatureResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SpaceFeature>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
                        var model = new ApiSpaceFeatureRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceFeature>())).Returns(Task.FromResult(new SpaceFeature()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));
                        var service = new SpaceFeatureService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                              mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        UpdateResponse<ApiSpaceFeatureResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SpaceFeature>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
                        var model = new ApiSpaceFeatureRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new SpaceFeatureService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                              mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void SpaceXSpaceFeatures_Exists()
                {
                        var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
                        var records = new List<SpaceXSpaceFeature>();
                        records.Add(new SpaceXSpaceFeature());
                        mock.RepositoryMock.Setup(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SpaceFeatureService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                              mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        List<ApiSpaceXSpaceFeatureResponseModel> response = await service.SpaceXSpaceFeatures(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SpaceXSpaceFeatures_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISpaceFeatureRepository>();
                        mock.RepositoryMock.Setup(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceXSpaceFeature>>(new List<SpaceXSpaceFeature>()));
                        var service = new SpaceFeatureService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
                                                              mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                              mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        List<ApiSpaceXSpaceFeatureResponseModel> response = await service.SpaceXSpaceFeatures(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>820cdbada68937bf80663cc9285a8495</Hash>
</Codenesium>*/