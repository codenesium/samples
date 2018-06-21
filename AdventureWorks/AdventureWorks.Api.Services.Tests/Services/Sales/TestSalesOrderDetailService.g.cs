using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesOrderDetail")]
        [Trait("Area", "Services")]
        public partial class SalesOrderDetailServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ISalesOrderDetailRepository>();
                        var records = new List<SalesOrderDetail>();
                        records.Add(new SalesOrderDetail());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesOrderDetailService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        List<ApiSalesOrderDetailResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ISalesOrderDetailRepository>();
                        var record = new SalesOrderDetail();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new SalesOrderDetailService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        ApiSalesOrderDetailResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ISalesOrderDetailRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesOrderDetail>(null));
                        var service = new SalesOrderDetailService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        ApiSalesOrderDetailResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ISalesOrderDetailRepository>();
                        var model = new ApiSalesOrderDetailRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesOrderDetail>())).Returns(Task.FromResult(new SalesOrderDetail()));
                        var service = new SalesOrderDetailService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        CreateResponse<ApiSalesOrderDetailResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesOrderDetailRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesOrderDetail>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ISalesOrderDetailRepository>();
                        var model = new ApiSalesOrderDetailRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesOrderDetail>())).Returns(Task.FromResult(new SalesOrderDetail()));
                        var service = new SalesOrderDetailService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesOrderDetailRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesOrderDetail>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ISalesOrderDetailRepository>();
                        var model = new ApiSalesOrderDetailRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new SalesOrderDetailService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderDetailRepository>();
                        var records = new List<SalesOrderDetail>();
                        records.Add(new SalesOrderDetail());
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesOrderDetailService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        List<ApiSalesOrderDetailResponseModel> response = await service.ByProductID(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByProductID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderDetailRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderDetail>>(new List<SalesOrderDetail>()));
                        var service = new SalesOrderDetailService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderDetailModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock);

                        List<ApiSalesOrderDetailResponseModel> response = await service.ByProductID(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>3c98bd4e2ad81fba57c5f8136c0c6682</Hash>
</Codenesium>*/