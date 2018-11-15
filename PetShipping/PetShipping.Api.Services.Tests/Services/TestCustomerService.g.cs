using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
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
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

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
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

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
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ApiCustomerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Customer>())).Returns(Task.FromResult(new Customer()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			CreateResponse<ApiCustomerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Customer>()));
		}

		[Fact]
		public async void Update()
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
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			UpdateResponse<ApiCustomerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Customer>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void CustomerCommunicationsByCustomerId_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			var records = new List<CustomerCommunication>();
			records.Add(new CustomerCommunication());
			mock.RepositoryMock.Setup(x => x.CustomerCommunicationsByCustomerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.CustomerCommunicationsByCustomerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CustomerCommunicationsByCustomerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CustomerCommunicationsByCustomerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerRepository>();
			mock.RepositoryMock.Setup(x => x.CustomerCommunicationsByCustomerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CustomerCommunication>>(new List<CustomerCommunication>()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.CustomerCommunicationsByCustomerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CustomerCommunicationsByCustomerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>56d788b577582f190c52dab1bc0df30c</Hash>
</Codenesium>*/