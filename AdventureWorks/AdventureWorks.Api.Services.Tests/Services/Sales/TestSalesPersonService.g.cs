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
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "Services")]
	public partial class SalesPersonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			var records = new List<SalesPerson>();
			records.Add(new SalesPerson());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			List<ApiSalesPersonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			var record = new SalesPerson();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			ApiSalesPersonServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			ApiSalesPersonServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			var model = new ApiSalesPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesPerson>())).Returns(Task.FromResult(new SalesPerson()));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			CreateResponse<ApiSalesPersonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesPerson>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			var model = new ApiSalesPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesPerson>())).Returns(Task.FromResult(new SalesPerson()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesPerson()));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			UpdateResponse<ApiSalesPersonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesPersonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesPerson>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			var model = new ApiSalesPersonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			var record = new SalesPerson();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			ApiSalesPersonServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesPerson>(null));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			ApiSalesPersonServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void SalesOrderHeadersBySalesPersonID_Exists()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			var records = new List<SalesOrderHeader>();
			records.Add(new SalesOrderHeader());
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersBySalesPersonID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersBySalesPersonID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersBySalesPersonID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesOrderHeadersBySalesPersonID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersBySalesPersonID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderHeader>>(new List<SalesOrderHeader>()));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersBySalesPersonID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersBySalesPersonID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StoresBySalesPersonID_Exists()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			var records = new List<Store>();
			records.Add(new Store());
			mock.RepositoryMock.Setup(x => x.StoresBySalesPersonID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			List<ApiStoreServerResponseModel> response = await service.StoresBySalesPersonID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.StoresBySalesPersonID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void StoresBySalesPersonID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesPersonRepository>();
			mock.RepositoryMock.Setup(x => x.StoresBySalesPersonID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Store>>(new List<Store>()));
			var service = new SalesPersonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesPersonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesPersonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesPersonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock,
			                                     mock.BOLMapperMockFactory.BOLStoreMapperMock,
			                                     mock.DALMapperMockFactory.DALStoreMapperMock);

			List<ApiStoreServerResponseModel> response = await service.StoresBySalesPersonID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.StoresBySalesPersonID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a85e33f241ff67a01945afa0d648207c</Hash>
</Codenesium>*/