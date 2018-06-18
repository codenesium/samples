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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Customer")]
        [Trait("Area", "Services")]
        public partial class CustomerServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ICustomerRepository>();
                        var records = new List<Customer>();
                        records.Add(new Customer());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CustomerService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                          mock.DALMapperMockFactory.DALCustomerMapperMock);

                        List<ApiCustomerResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ICustomerRepository>();
                        var record = new Customer();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new CustomerService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                          mock.DALMapperMockFactory.DALCustomerMapperMock);

                        ApiCustomerResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ICustomerRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));
                        var service = new CustomerService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                          mock.DALMapperMockFactory.DALCustomerMapperMock);

                        ApiCustomerResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ICustomerRepository>();
                        var model = new ApiCustomerRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Customer>())).Returns(Task.FromResult(new Customer()));
                        var service = new CustomerService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                          mock.DALMapperMockFactory.DALCustomerMapperMock);

                        CreateResponse<ApiCustomerResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Customer>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ICustomerRepository>();
                        var model = new ApiCustomerRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Customer>())).Returns(Task.FromResult(new Customer()));
                        var service = new CustomerService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                          mock.DALMapperMockFactory.DALCustomerMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Customer>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ICustomerRepository>();
                        var model = new ApiCustomerRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new CustomerService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLCustomerMapperMock,
                                                          mock.DALMapperMockFactory.DALCustomerMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>e87a2ff4bb3d8d10c2096c951dca820b</Hash>
</Codenesium>*/