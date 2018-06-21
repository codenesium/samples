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
        [Trait("Table", "User")]
        [Trait("Area", "Services")]
        public partial class UserServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        var records = new List<User>();
                        records.Add(new User());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        List<ApiUserResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        var record = new User();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        ApiUserResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<User>(null));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        ApiUserResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        var model = new ApiUserRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        CreateResponse<ApiUserResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUserRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<User>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        var model = new ApiUserRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<User>())).Returns(Task.FromResult(new User()));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiUserRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<User>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        var model = new ApiUserRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.UserModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetUsername_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        var record = new User();
                        mock.RepositoryMock.Setup(x => x.GetUsername(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        ApiUserResponseModel response = await service.GetUsername(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetUsername(It.IsAny<string>()));
                }

                [Fact]
                public async void GetUsername_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        mock.RepositoryMock.Setup(x => x.GetUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(null));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        ApiUserResponseModel response = await service.GetUsername(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetUsername(It.IsAny<string>()));
                }

                [Fact]
                public async void GetDisplayName_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        var records = new List<User>();
                        records.Add(new User());
                        mock.RepositoryMock.Setup(x => x.GetDisplayName(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        List<ApiUserResponseModel> response = await service.GetDisplayName(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDisplayName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetDisplayName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        mock.RepositoryMock.Setup(x => x.GetDisplayName(It.IsAny<string>())).Returns(Task.FromResult<List<User>>(new List<User>()));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        List<ApiUserResponseModel> response = await service.GetDisplayName(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDisplayName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetEmailAddress_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        var records = new List<User>();
                        records.Add(new User());
                        mock.RepositoryMock.Setup(x => x.GetEmailAddress(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        List<ApiUserResponseModel> response = await service.GetEmailAddress(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetEmailAddress(It.IsAny<string>()));
                }

                [Fact]
                public async void GetEmailAddress_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        mock.RepositoryMock.Setup(x => x.GetEmailAddress(It.IsAny<string>())).Returns(Task.FromResult<List<User>>(new List<User>()));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        List<ApiUserResponseModel> response = await service.GetEmailAddress(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetEmailAddress(It.IsAny<string>()));
                }

                [Fact]
                public async void GetExternalId_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        var records = new List<User>();
                        records.Add(new User());
                        mock.RepositoryMock.Setup(x => x.GetExternalId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        List<ApiUserResponseModel> response = await service.GetExternalId(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetExternalId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetExternalId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IUserRepository>();
                        mock.RepositoryMock.Setup(x => x.GetExternalId(It.IsAny<string>())).Returns(Task.FromResult<List<User>>(new List<User>()));
                        var service = new UserService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.UserModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLUserMapperMock,
                                                      mock.DALMapperMockFactory.DALUserMapperMock);

                        List<ApiUserResponseModel> response = await service.GetExternalId(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetExternalId(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>e024c571f0987dc49a72ccb3881e1cad</Hash>
</Codenesium>*/