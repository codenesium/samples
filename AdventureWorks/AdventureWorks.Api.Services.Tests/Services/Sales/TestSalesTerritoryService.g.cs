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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			List<ApiSalesTerritoryResponseModel> response = await service.All();

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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			ApiSalesTerritoryResponseModel response = await service.Get(default(int));

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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			ApiSalesTerritoryResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var model = new ApiSalesTerritoryRequestModel();
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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			CreateResponse<ApiSalesTerritoryResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTerritoryRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesTerritory>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var model = new ApiSalesTerritoryRequestModel();
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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			UpdateResponse<ApiSalesTerritoryResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesTerritoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTerritoryRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesTerritory>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var model = new ApiSalesTerritoryRequestModel();
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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			ApiSalesTerritoryResponseModel response = await service.ByName(default(string));

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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			ApiSalesTerritoryResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			List<ApiCustomerResponseModel> response = await service.CustomersByTerritoryID(default(int));

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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			List<ApiCustomerResponseModel> response = await service.CustomersByTerritoryID(default(int));

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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			List<ApiSalesOrderHeaderResponseModel> response = await service.SalesOrderHeadersByTerritoryID(default(int));

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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			List<ApiSalesOrderHeaderResponseModel> response = await service.SalesOrderHeadersByTerritoryID(default(int));

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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			List<ApiSalesPersonResponseModel> response = await service.SalesPersonsByTerritoryID(default(int));

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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			List<ApiSalesPersonResponseModel> response = await service.SalesPersonsByTerritoryID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesPersonsByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesTerritoryHistoriesByTerritoryID_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			var records = new List<SalesTerritoryHistory>();
			records.Add(new SalesTerritoryHistory());
			mock.RepositoryMock.Setup(x => x.SalesTerritoryHistoriesByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			List<ApiSalesTerritoryHistoryResponseModel> response = await service.SalesTerritoryHistoriesByTerritoryID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesTerritoryHistoriesByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesTerritoryHistoriesByTerritoryID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTerritoryRepository>();
			mock.RepositoryMock.Setup(x => x.SalesTerritoryHistoriesByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesTerritoryHistory>>(new List<SalesTerritoryHistory>()));
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
			                                        mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                        mock.BOLMapperMockFactory.BOLSalesTerritoryHistoryMapperMock,
			                                        mock.DALMapperMockFactory.DALSalesTerritoryHistoryMapperMock);

			List<ApiSalesTerritoryHistoryResponseModel> response = await service.SalesTerritoryHistoriesByTerritoryID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesTerritoryHistoriesByTerritoryID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>11214396f43724e62ca335bfd91a456d</Hash>
</Codenesium>*/