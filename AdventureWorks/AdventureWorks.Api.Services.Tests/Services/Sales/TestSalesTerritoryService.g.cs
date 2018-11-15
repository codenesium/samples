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
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "Services")]
	public partial class SalesTerritoryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var records = new List<SalesTerritory>();
			records.Add(new SalesTerritory());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			List<ApiSalesTerritoryServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var record = new SalesTerritory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			ApiSalesTerritoryServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			ApiSalesTerritoryServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var model = new ApiSalesTerritoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesTerritory>())).Returns(Task.FromResult(new SalesTerritory()));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			CreateResponse<ApiSalesTerritoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTerritoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesTerritory>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var model = new ApiSalesTerritoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesTerritory>())).Returns(Task.FromResult(new SalesTerritory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			UpdateResponse<ApiSalesTerritoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesTerritory>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var model = new ApiSalesTerritoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var record = new SalesTerritory();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			ApiSalesTerritoryServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<SalesTerritory>(null));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			ApiSalesTerritoryServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var record = new SalesTerritory();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			ApiSalesTerritoryServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesTerritory>(null));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			ApiSalesTerritoryServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void CustomersByTerritoryID_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var records = new List<Customer>();
			records.Add(new Customer());
			mock.RepositoryMock.Setup(x => x.CustomersByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			List<ApiCustomerServerResponseModel> response = await service.CustomersByTerritoryID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CustomersByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CustomersByTerritoryID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			mock.RepositoryMock.Setup(x => x.CustomersByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Customer>>(new List<Customer>()));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			List<ApiCustomerServerResponseModel> response = await service.CustomersByTerritoryID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CustomersByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesOrderHeadersByTerritoryID_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var records = new List<SalesOrderHeader>();
			records.Add(new SalesOrderHeader());
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByTerritoryID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesOrderHeadersByTerritoryID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderHeader>>(new List<SalesOrderHeader>()));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByTerritoryID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesPersonsByTerritoryID_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var records = new List<SalesPerson>();
			records.Add(new SalesPerson());
			mock.RepositoryMock.Setup(x => x.SalesPersonsByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			List<ApiSalesPersonServerResponseModel> response = await service.SalesPersonsByTerritoryID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesPersonsByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesPersonsByTerritoryID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			mock.RepositoryMock.Setup(x => x.SalesPersonsByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesPerson>>(new List<SalesPerson>()));
			var service = new SalesTerritoryService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryMapperMock,
			                                        mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                        mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock);

			List<ApiSalesPersonServerResponseModel> response = await service.SalesPersonsByTerritoryID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesPersonsByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>83302b3c49de79fe52292b3fb2816346</Hash>
</Codenesium>*/