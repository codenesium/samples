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
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Admin")]
        [Trait("Area", "Services")]
        public partial class AdminServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IAdminRepository>();
                        var records = new List<Admin>();
                        records.Add(new Admin());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new AdminService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                       mock.DALMapperMockFactory.DALAdminMapperMock);

                        List<ApiAdminResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IAdminRepository>();
                        var record = new Admin();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new AdminService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                       mock.DALMapperMockFactory.DALAdminMapperMock);

                        ApiAdminResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IAdminRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Admin>(null));
                        var service = new AdminService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                       mock.DALMapperMockFactory.DALAdminMapperMock);

                        ApiAdminResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IAdminRepository>();
                        var model = new ApiAdminRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Admin>())).Returns(Task.FromResult(new Admin()));
                        var service = new AdminService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                       mock.DALMapperMockFactory.DALAdminMapperMock);

                        CreateResponse<ApiAdminResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.AdminModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAdminRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Admin>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IAdminRepository>();
                        var model = new ApiAdminRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Admin>())).Returns(Task.FromResult(new Admin()));
                        var service = new AdminService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                       mock.DALMapperMockFactory.DALAdminMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.AdminModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Admin>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IAdminRepository>();
                        var model = new ApiAdminRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new AdminService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.AdminModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLAdminMapperMock,
                                                       mock.DALMapperMockFactory.DALAdminMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.AdminModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>718cc56c1126709a05eed729c873f5c8</Hash>
</Codenesium>*/