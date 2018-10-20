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
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

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
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCustomerResponseModel response = await service.Get(default(int));

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
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCustomerResponseModel response = await service.Get(default(int));

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
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

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
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			UpdateResponse<ApiCustomerResponseModel> response = await service.Update(default(int), model);

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
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByAccountNumber_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var record = new Customer();
			mock.RepositoryMock.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCustomerResponseModel response = await service.ByAccountNumber(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByAccountNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void ByAccountNumber_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			mock.RepositoryMock.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Customer>(null));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCustomerResponseModel response = await service.ByAccountNumber(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByAccountNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void ByTerritoryID_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var records = new List<Customer>();
			records.Add(new Customer());
			mock.RepositoryMock.Setup(x => x.ByTerritoryID(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiCustomerResponseModel> response = await service.ByTerritoryID(default(int?));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTerritoryID(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTerritoryID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			mock.RepositoryMock.Setup(x => x.ByTerritoryID(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Customer>>(new List<Customer>()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiCustomerResponseModel> response = await service.ByTerritoryID(default(int?));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTerritoryID(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesOrderHeadersByCustomerID_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var records = new List<SalesOrderHeader>();
			records.Add(new SalesOrderHeader());
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByCustomerID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiSalesOrderHeaderResponseModel> response = await service.SalesOrderHeadersByCustomerID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByCustomerID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesOrderHeadersByCustomerID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByCustomerID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderHeader>>(new List<SalesOrderHeader>()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiSalesOrderHeaderResponseModel> response = await service.SalesOrderHeadersByCustomerID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByCustomerID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>33f5b93ea071ad945c451361754ce908</Hash>
</Codenesium>*/