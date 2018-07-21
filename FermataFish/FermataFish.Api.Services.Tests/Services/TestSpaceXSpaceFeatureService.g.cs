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
        [Trait("Table", "SpaceXSpaceFeature")]
        [Trait("Area", "Services")]
        public partial class SpaceXSpaceFeatureServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ISpaceXSpaceFeatureRepository>();
                        var records = new List<SpaceXSpaceFeature>();
                        records.Add(new SpaceXSpaceFeature());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SpaceXSpaceFeatureService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.SpaceXSpaceFeatureModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                                    mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        List<ApiSpaceXSpaceFeatureResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ISpaceXSpaceFeatureRepository>();
                        var record = new SpaceXSpaceFeature();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new SpaceXSpaceFeatureService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.SpaceXSpaceFeatureModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                                    mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        ApiSpaceXSpaceFeatureResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ISpaceXSpaceFeatureRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SpaceXSpaceFeature>(null));
                        var service = new SpaceXSpaceFeatureService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.SpaceXSpaceFeatureModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                                    mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        ApiSpaceXSpaceFeatureResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ISpaceXSpaceFeatureRepository>();
                        var model = new ApiSpaceXSpaceFeatureRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceXSpaceFeature>())).Returns(Task.FromResult(new SpaceXSpaceFeature()));
                        var service = new SpaceXSpaceFeatureService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.SpaceXSpaceFeatureModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                                    mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        CreateResponse<ApiSpaceXSpaceFeatureResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SpaceXSpaceFeatureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SpaceXSpaceFeature>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ISpaceXSpaceFeatureRepository>();
                        var model = new ApiSpaceXSpaceFeatureRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceXSpaceFeature>())).Returns(Task.FromResult(new SpaceXSpaceFeature()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceXSpaceFeature()));
                        var service = new SpaceXSpaceFeatureService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.SpaceXSpaceFeatureModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                                    mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        UpdateResponse<ApiSpaceXSpaceFeatureResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SpaceXSpaceFeatureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceXSpaceFeatureRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SpaceXSpaceFeature>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ISpaceXSpaceFeatureRepository>();
                        var model = new ApiSpaceXSpaceFeatureRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new SpaceXSpaceFeatureService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.SpaceXSpaceFeatureModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
                                                                    mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.SpaceXSpaceFeatureModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>155dc24ed280ca3c5f70e5f0e162f958</Hash>
</Codenesium>*/