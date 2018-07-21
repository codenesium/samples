using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Users")]
        [Trait("Area", "Services")]
        public partial class UsersServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IUsersRepository>();
                        var records = new List<Users>();
                        records.Add(new Users());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new UsersService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLUsersMapperMock,
                                                       mock.DALMapperMockFactory.DALUsersMapperMock);

                        List<ApiUsersResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IUsersRepository>();
                        var record = new Users();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new UsersService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLUsersMapperMock,
                                                       mock.DALMapperMockFactory.DALUsersMapperMock);

                        ApiUsersResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IUsersRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));
                        var service = new UsersService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLUsersMapperMock,
                                                       mock.DALMapperMockFactory.DALUsersMapperMock);

                        ApiUsersResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IUsersRepository>();
                        var model = new ApiUsersRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Users>())).Returns(Task.FromResult(new Users()));
                        var service = new UsersService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLUsersMapperMock,
                                                       mock.DALMapperMockFactory.DALUsersMapperMock);

                        CreateResponse<ApiUsersResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.UsersModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUsersRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Users>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IUsersRepository>();
                        var model = new ApiUsersRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Users>())).Returns(Task.FromResult(new Users()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));
                        var service = new UsersService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLUsersMapperMock,
                                                       mock.DALMapperMockFactory.DALUsersMapperMock);

                        UpdateResponse<ApiUsersResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.UsersModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUsersRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Users>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IUsersRepository>();
                        var model = new ApiUsersRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new UsersService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.UsersModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLUsersMapperMock,
                                                       mock.DALMapperMockFactory.DALUsersMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.UsersModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>74c686172decd8ee1899aba920a22f28</Hash>
</Codenesium>*/