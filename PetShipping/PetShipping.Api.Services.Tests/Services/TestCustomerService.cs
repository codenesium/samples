using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
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
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();
			var records = new List<Customer>();
			records.Add(new Customer());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();
			var record = new Customer();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ApiCustomerServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ApiCustomerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();

			var model = new ApiCustomerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Customer>())).Returns(Task.FromResult(new Customer()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			CreateResponse<ApiCustomerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Customer>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			var validatorMock = new Mock<IApiCustomerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			CreateResponse<ApiCustomerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Customer>())).Returns(Task.FromResult(new Customer()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			UpdateResponse<ApiCustomerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Customer>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			var validatorMock = new Mock<IApiCustomerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			UpdateResponse<ApiCustomerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();
			var model = new ApiCustomerServerRequestModel();
			var validatorMock = new Mock<IApiCustomerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CustomerCommunicationsByCustomerId_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();
			var records = new List<CustomerCommunication>();
			records.Add(new CustomerCommunication());
			mock.RepositoryMock.Setup(x => x.CustomerCommunicationsByCustomerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.CustomerCommunicationsByCustomerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CustomerCommunicationsByCustomerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CustomerCommunicationsByCustomerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerService, ICustomerRepository>();
			mock.RepositoryMock.Setup(x => x.CustomerCommunicationsByCustomerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CustomerCommunication>>(new List<CustomerCommunication>()));
			var service = new CustomerService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CustomerModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCustomerMapperMock,
			                                  mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.CustomerCommunicationsByCustomerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CustomerCommunicationsByCustomerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>53d0aed6ed2cc05068b1615f30f8a1c7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/