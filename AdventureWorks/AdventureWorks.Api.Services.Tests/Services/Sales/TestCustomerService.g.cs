using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
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

			List<ApiCustomerServerResponseModel> response = await service.All();

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

			ApiCustomerServerResponseModel response = await service.Get(default(int));

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

			ApiCustomerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Customer>())).Returns(Task.FromResult(new Customer()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			CreateResponse<ApiCustomerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Customer>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			var validatorMock = new Mock<IApiCustomerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			CreateResponse<ApiCustomerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Customer>())).Returns(Task.FromResult(new Customer()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			UpdateResponse<ApiCustomerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Customer>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			var validatorMock = new Mock<IApiCustomerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			UpdateResponse<ApiCustomerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
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
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			var validatorMock = new Mock<IApiCustomerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
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

			ApiCustomerServerResponseModel response = await service.ByAccountNumber("test_value");

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

			ApiCustomerServerResponseModel response = await service.ByAccountNumber("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByAccountNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var record = new Customer();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCustomerServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Customer>(null));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                  mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCustomerServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
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

			List<ApiCustomerServerResponseModel> response = await service.ByTerritoryID(default(int));

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

			List<ApiCustomerServerResponseModel> response = await service.ByTerritoryID(default(int));

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

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByCustomerID(default(int));

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

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByCustomerID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByCustomerID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>ea9107938cf7cfc0135478f82aaa8e37</Hash>
</Codenesium>*/