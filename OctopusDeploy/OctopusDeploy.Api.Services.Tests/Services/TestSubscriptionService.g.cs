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
        [Trait("Table", "Subscription")]
        [Trait("Area", "Services")]
        public partial class SubscriptionServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ISubscriptionRepository>();
                        var records = new List<Subscription>();
                        records.Add(new Subscription());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SubscriptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSubscriptionMapperMock,
                                                              mock.DALMapperMockFactory.DALSubscriptionMapperMock);

                        List<ApiSubscriptionResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ISubscriptionRepository>();
                        var record = new Subscription();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new SubscriptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSubscriptionMapperMock,
                                                              mock.DALMapperMockFactory.DALSubscriptionMapperMock);

                        ApiSubscriptionResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ISubscriptionRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Subscription>(null));
                        var service = new SubscriptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSubscriptionMapperMock,
                                                              mock.DALMapperMockFactory.DALSubscriptionMapperMock);

                        ApiSubscriptionResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ISubscriptionRepository>();
                        var model = new ApiSubscriptionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Subscription>())).Returns(Task.FromResult(new Subscription()));
                        var service = new SubscriptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSubscriptionMapperMock,
                                                              mock.DALMapperMockFactory.DALSubscriptionMapperMock);

                        CreateResponse<ApiSubscriptionResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSubscriptionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Subscription>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ISubscriptionRepository>();
                        var model = new ApiSubscriptionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Subscription>())).Returns(Task.FromResult(new Subscription()));
                        var service = new SubscriptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSubscriptionMapperMock,
                                                              mock.DALMapperMockFactory.DALSubscriptionMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiSubscriptionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Subscription>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ISubscriptionRepository>();
                        var model = new ApiSubscriptionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new SubscriptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSubscriptionMapperMock,
                                                              mock.DALMapperMockFactory.DALSubscriptionMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<ISubscriptionRepository>();
                        var record = new Subscription();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new SubscriptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSubscriptionMapperMock,
                                                              mock.DALMapperMockFactory.DALSubscriptionMapperMock);

                        ApiSubscriptionResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISubscriptionRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Subscription>(null));
                        var service = new SubscriptionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.SubscriptionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLSubscriptionMapperMock,
                                                              mock.DALMapperMockFactory.DALSubscriptionMapperMock);

                        ApiSubscriptionResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>0c77fa47f095a952bb11142f6e24f2c4</Hash>
</Codenesium>*/