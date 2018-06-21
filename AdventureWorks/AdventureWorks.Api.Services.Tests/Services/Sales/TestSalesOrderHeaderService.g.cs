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
        [Trait("Table", "SalesOrderHeader")]
        [Trait("Area", "Services")]
        public partial class SalesOrderHeaderServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var records = new List<SalesOrderHeader>();
                        records.Add(new SalesOrderHeader());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        List<ApiSalesOrderHeaderResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var record = new SalesOrderHeader();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        ApiSalesOrderHeaderResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesOrderHeader>(null));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        ApiSalesOrderHeaderResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var model = new ApiSalesOrderHeaderRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesOrderHeader>())).Returns(Task.FromResult(new SalesOrderHeader()));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        CreateResponse<ApiSalesOrderHeaderResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesOrderHeaderRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesOrderHeader>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var model = new ApiSalesOrderHeaderRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesOrderHeader>())).Returns(Task.FromResult(new SalesOrderHeader()));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesOrderHeader>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var model = new ApiSalesOrderHeaderRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void BySalesOrderNumber_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var record = new SalesOrderHeader();
                        mock.RepositoryMock.Setup(x => x.BySalesOrderNumber(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        ApiSalesOrderHeaderResponseModel response = await service.BySalesOrderNumber(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.BySalesOrderNumber(It.IsAny<string>()));
                }

                [Fact]
                public async void BySalesOrderNumber_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        mock.RepositoryMock.Setup(x => x.BySalesOrderNumber(It.IsAny<string>())).Returns(Task.FromResult<SalesOrderHeader>(null));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        ApiSalesOrderHeaderResponseModel response = await service.BySalesOrderNumber(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.BySalesOrderNumber(It.IsAny<string>()));
                }

                [Fact]
                public async void ByCustomerID_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var records = new List<SalesOrderHeader>();
                        records.Add(new SalesOrderHeader());
                        mock.RepositoryMock.Setup(x => x.ByCustomerID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        List<ApiSalesOrderHeaderResponseModel> response = await service.ByCustomerID(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByCustomerID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByCustomerID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        mock.RepositoryMock.Setup(x => x.ByCustomerID(It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderHeader>>(new List<SalesOrderHeader>()));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        List<ApiSalesOrderHeaderResponseModel> response = await service.ByCustomerID(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByCustomerID(It.IsAny<int>()));
                }

                [Fact]
                public async void BySalesPersonID_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var records = new List<SalesOrderHeader>();
                        records.Add(new SalesOrderHeader());
                        mock.RepositoryMock.Setup(x => x.BySalesPersonID(It.IsAny<Nullable<int>>())).Returns(Task.FromResult(records));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        List<ApiSalesOrderHeaderResponseModel> response = await service.BySalesPersonID(default(Nullable<int>));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.BySalesPersonID(It.IsAny<Nullable<int>>()));
                }

                [Fact]
                public async void BySalesPersonID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        mock.RepositoryMock.Setup(x => x.BySalesPersonID(It.IsAny<Nullable<int>>())).Returns(Task.FromResult<List<SalesOrderHeader>>(new List<SalesOrderHeader>()));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        List<ApiSalesOrderHeaderResponseModel> response = await service.BySalesPersonID(default(Nullable<int>));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.BySalesPersonID(It.IsAny<Nullable<int>>()));
                }

                [Fact]
                public async void SalesOrderDetails_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var records = new List<SalesOrderDetail>();
                        records.Add(new SalesOrderDetail());
                        mock.RepositoryMock.Setup(x => x.SalesOrderDetails(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        List<ApiSalesOrderDetailResponseModel> response = await service.SalesOrderDetails(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesOrderDetails(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SalesOrderDetails_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        mock.RepositoryMock.Setup(x => x.SalesOrderDetails(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderDetail>>(new List<SalesOrderDetail>()));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        List<ApiSalesOrderDetailResponseModel> response = await service.SalesOrderDetails(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesOrderDetails(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SalesOrderHeaderSalesReasons_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        var records = new List<SalesOrderHeaderSalesReason>();
                        records.Add(new SalesOrderHeaderSalesReason());
                        mock.RepositoryMock.Setup(x => x.SalesOrderHeaderSalesReasons(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        List<ApiSalesOrderHeaderSalesReasonResponseModel> response = await service.SalesOrderHeaderSalesReasons(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesOrderHeaderSalesReasons(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SalesOrderHeaderSalesReasons_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ISalesOrderHeaderRepository>();
                        mock.RepositoryMock.Setup(x => x.SalesOrderHeaderSalesReasons(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderHeaderSalesReason>>(new List<SalesOrderHeaderSalesReason>()));
                        var service = new SalesOrderHeaderService(mock.LoggerMock.Object,
                                                                  mock.RepositoryMock.Object,
                                                                  mock.ModelValidatorMockFactory.SalesOrderHeaderModelValidatorMock.Object,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderDetailMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderDetailMapperMock,
                                                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
                                                                  mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

                        List<ApiSalesOrderHeaderSalesReasonResponseModel> response = await service.SalesOrderHeaderSalesReasons(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.SalesOrderHeaderSalesReasons(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>57b5be1a77f6969a27d26926dfb02966</Hash>
</Codenesium>*/