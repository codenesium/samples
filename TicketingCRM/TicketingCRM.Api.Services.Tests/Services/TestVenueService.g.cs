using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Venue")]
        [Trait("Area", "Services")]
        public partial class VenueServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        var records = new List<Venue>();
                        records.Add(new Venue());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        List<ApiVenueResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        var record = new Venue();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        ApiVenueResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Venue>(null));
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        ApiVenueResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        var model = new ApiVenueRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Venue>())).Returns(Task.FromResult(new Venue()));
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        CreateResponse<ApiVenueResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.VenueModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVenueRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Venue>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        var model = new ApiVenueRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Venue>())).Returns(Task.FromResult(new Venue()));
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.VenueModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVenueRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Venue>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        var model = new ApiVenueRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.VenueModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void GetAdminId_Exists()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        var records = new List<Venue>();
                        records.Add(new Venue());
                        mock.RepositoryMock.Setup(x => x.GetAdminId(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        List<ApiVenueResponseModel> response = await service.GetAdminId(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetAdminId(It.IsAny<int>()));
                }

                [Fact]
                public async void GetAdminId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        mock.RepositoryMock.Setup(x => x.GetAdminId(It.IsAny<int>())).Returns(Task.FromResult<List<Venue>>(new List<Venue>()));
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        List<ApiVenueResponseModel> response = await service.GetAdminId(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetAdminId(It.IsAny<int>()));
                }

                [Fact]
                public async void GetProvinceId_Exists()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        var records = new List<Venue>();
                        records.Add(new Venue());
                        mock.RepositoryMock.Setup(x => x.GetProvinceId(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        List<ApiVenueResponseModel> response = await service.GetProvinceId(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetProvinceId(It.IsAny<int>()));
                }

                [Fact]
                public async void GetProvinceId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IVenueRepository>();
                        mock.RepositoryMock.Setup(x => x.GetProvinceId(It.IsAny<int>())).Returns(Task.FromResult<List<Venue>>(new List<Venue>()));
                        var service = new VenueService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.VenueModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLVenueMapperMock,
                                                       mock.DALMapperMockFactory.DALVenueMapperMock);

                        List<ApiVenueResponseModel> response = await service.GetProvinceId(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetProvinceId(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>914cc74cab0d75f583c1e9ed300821f7</Hash>
</Codenesium>*/