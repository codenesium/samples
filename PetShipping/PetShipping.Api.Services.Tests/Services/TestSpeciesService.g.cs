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
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Species")]
        [Trait("Area", "Services")]
        public partial class SpeciesServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ISpeciesRepository>();
                        var records = new List<Species>();
                        records.Add(new Species());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SpeciesService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
                                                         mock.DALMapperMockFactory.DALSpeciesMapperMock,
                                                         mock.BOLMapperMockFactory.BOLBreedMapperMock,
                                                         mock.DALMapperMockFactory.DALBreedMapperMock);

                        List<ApiSpeciesResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ISpeciesRepository>();
                        var record = new Species();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new SpeciesService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
                                                         mock.DALMapperMockFactory.DALSpeciesMapperMock,
                                                         mock.BOLMapperMockFactory.BOLBreedMapperMock,
                                                         mock.DALMapperMockFactory.DALBreedMapperMock);

                        ApiSpeciesResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ISpeciesRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Species>(null));
                        var service = new SpeciesService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
                                                         mock.DALMapperMockFactory.DALSpeciesMapperMock,
                                                         mock.BOLMapperMockFactory.BOLBreedMapperMock,
                                                         mock.DALMapperMockFactory.DALBreedMapperMock);

                        ApiSpeciesResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ISpeciesRepository>();
                        var model = new ApiSpeciesRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Species>())).Returns(Task.FromResult(new Species()));
                        var service = new SpeciesService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
                                                         mock.DALMapperMockFactory.DALSpeciesMapperMock,
                                                         mock.BOLMapperMockFactory.BOLBreedMapperMock,
                                                         mock.DALMapperMockFactory.DALBreedMapperMock);

                        CreateResponse<ApiSpeciesResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpeciesRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Species>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ISpeciesRepository>();
                        var model = new ApiSpeciesRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Species>())).Returns(Task.FromResult(new Species()));
                        var service = new SpeciesService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
                                                         mock.DALMapperMockFactory.DALSpeciesMapperMock,
                                                         mock.BOLMapperMockFactory.BOLBreedMapperMock,
                                                         mock.DALMapperMockFactory.DALBreedMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpeciesRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Species>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ISpeciesRepository>();
                        var model = new ApiSpeciesRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new SpeciesService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
                                                         mock.DALMapperMockFactory.DALSpeciesMapperMock,
                                                         mock.BOLMapperMockFactory.BOLBreedMapperMock,
                                                         mock.DALMapperMockFactory.DALBreedMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void Breeds_Exists()
                {
                        var mock = new ServiceMockFacade<ISpeciesRepository>();
                        var records = new List<Breed>();
                        records.Add(new Breed());
                        mock.RepositoryMock.Setup(x => x.Breeds(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SpeciesService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
                                                         mock.DALMapperMockFactory.DALSpeciesMapperMock,
                                                         mock.BOLMapperMockFactory.BOLBreedMapperMock,
                                                         mock.DALMapperMockFactory.DALBreedMapperMock);

                        List<ApiBreedResponseModel> response = await service.Breeds(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Breeds(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Breeds_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISpeciesRepository>();
                        mock.RepositoryMock.Setup(x => x.Breeds(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Breed>>(new List<Breed>()));
                        var service = new SpeciesService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
                                                         mock.DALMapperMockFactory.DALSpeciesMapperMock,
                                                         mock.BOLMapperMockFactory.BOLBreedMapperMock,
                                                         mock.DALMapperMockFactory.DALBreedMapperMock);

                        List<ApiBreedResponseModel> response = await service.Breeds(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Breeds(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>bf3606f3ff03b89507bae0f85b638480</Hash>
</Codenesium>*/