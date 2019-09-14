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
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "Services")]
	public partial class CustomerCommunicationServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			var records = new List<CustomerCommunication>();
			records.Add(new CustomerCommunication());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			var record = new CustomerCommunication();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ApiCustomerCommunicationServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CustomerCommunication>(null));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ApiCustomerCommunicationServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();

			var model = new ApiCustomerCommunicationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CustomerCommunication>())).Returns(Task.FromResult(new CustomerCommunication()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			CreateResponse<ApiCustomerCommunicationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CustomerCommunication>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerCommunicationCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			var validatorMock = new Mock<IApiCustomerCommunicationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               validatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			CreateResponse<ApiCustomerCommunicationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerCommunicationCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CustomerCommunication>())).Returns(Task.FromResult(new CustomerCommunication()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CustomerCommunication()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			UpdateResponse<ApiCustomerCommunicationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CustomerCommunication>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerCommunicationUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			var validatorMock = new Mock<IApiCustomerCommunicationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CustomerCommunication()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               validatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			UpdateResponse<ApiCustomerCommunicationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerCommunicationUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerCommunicationDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			var validatorMock = new Mock<IApiCustomerCommunicationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               validatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CustomerCommunicationDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByCustomerId_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			var records = new List<CustomerCommunication>();
			records.Add(new CustomerCommunication());
			mock.RepositoryMock.Setup(x => x.ByCustomerId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.ByCustomerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCustomerId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByCustomerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			mock.RepositoryMock.Setup(x => x.ByCustomerId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CustomerCommunication>>(new List<CustomerCommunication>()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.ByCustomerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCustomerId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByEmployeeId_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			var records = new List<CustomerCommunication>();
			records.Add(new CustomerCommunication());
			mock.RepositoryMock.Setup(x => x.ByEmployeeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.ByEmployeeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmployeeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByEmployeeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationService, ICustomerCommunicationRepository>();
			mock.RepositoryMock.Setup(x => x.ByEmployeeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CustomerCommunication>>(new List<CustomerCommunication>()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.MediatorMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.ByEmployeeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmployeeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6fce2bb773b3d3e20955f2b8eedaea3e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/