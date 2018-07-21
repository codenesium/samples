using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "UserRole")]
        [Trait("Area", "Services")]
        public partial class UserRoleServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IUserRoleRepository>();
                        var records = new List<UserRole>();
                        records.Add(new UserRole());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new UserRoleService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLUserRoleMapperMock,
                                                          mock.DALMapperMockFactory.DALUserRoleMapperMock);

                        List<ApiUserRoleResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IUserRoleRepository>();
                        var record = new UserRole();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new UserRoleService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLUserRoleMapperMock,
                                                          mock.DALMapperMockFactory.DALUserRoleMapperMock);

                        ApiUserRoleResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IUserRoleRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<UserRole>(null));
                        var service = new UserRoleService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLUserRoleMapperMock,
                                                          mock.DALMapperMockFactory.DALUserRoleMapperMock);

                        ApiUserRoleResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IUserRoleRepository>();
                        var model = new ApiUserRoleRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<UserRole>())).Returns(Task.FromResult(new UserRole()));
                        var service = new UserRoleService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLUserRoleMapperMock,
                                                          mock.DALMapperMockFactory.DALUserRoleMapperMock);

                        CreateResponse<ApiUserRoleResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUserRoleRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<UserRole>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IUserRoleRepository>();
                        var model = new ApiUserRoleRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<UserRole>())).Returns(Task.FromResult(new UserRole()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UserRole()));
                        var service = new UserRoleService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLUserRoleMapperMock,
                                                          mock.DALMapperMockFactory.DALUserRoleMapperMock);

                        UpdateResponse<ApiUserRoleResponseModel> response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiUserRoleRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<UserRole>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IUserRoleRepository>();
                        var model = new ApiUserRoleRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new UserRoleService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLUserRoleMapperMock,
                                                          mock.DALMapperMockFactory.DALUserRoleMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRoleRepository>();
                        var record = new UserRole();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new UserRoleService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLUserRoleMapperMock,
                                                          mock.DALMapperMockFactory.DALUserRoleMapperMock);

                        ApiUserRoleResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRoleRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UserRole>(null));
                        var service = new UserRoleService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.UserRoleModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLUserRoleMapperMock,
                                                          mock.DALMapperMockFactory.DALUserRoleMapperMock);

                        ApiUserRoleResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>bb8efce154d61106847d7102756fac38</Hash>
</Codenesium>*/