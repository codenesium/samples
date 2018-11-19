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
		public async void All()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var records = new List<CustomerCommunication>();
			records.Add(new CustomerCommunication());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var record = new CustomerCommunication();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ApiCustomerCommunicationServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CustomerCommunication>(null));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ApiCustomerCommunicationServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CustomerCommunication>())).Returns(Task.FromResult(new CustomerCommunication()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			CreateResponse<ApiCustomerCommunicationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CustomerCommunication>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			var validatorMock = new Mock<IApiCustomerCommunicationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               validatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			CreateResponse<ApiCustomerCommunicationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CustomerCommunication>())).Returns(Task.FromResult(new CustomerCommunication()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CustomerCommunication()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			UpdateResponse<ApiCustomerCommunicationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CustomerCommunication>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			var validatorMock = new Mock<IApiCustomerCommunicationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CustomerCommunication()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               validatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			UpdateResponse<ApiCustomerCommunicationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCustomerCommunicationServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var model = new ApiCustomerCommunicationServerRequestModel();
			var validatorMock = new Mock<IApiCustomerCommunicationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               validatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByCustomerId_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var records = new List<CustomerCommunication>();
			records.Add(new CustomerCommunication());
			mock.RepositoryMock.Setup(x => x.ByCustomerId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.ByCustomerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCustomerId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByCustomerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			mock.RepositoryMock.Setup(x => x.ByCustomerId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CustomerCommunication>>(new List<CustomerCommunication>()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.ByCustomerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCustomerId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByEmployeeId_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			var records = new List<CustomerCommunication>();
			records.Add(new CustomerCommunication());
			mock.RepositoryMock.Setup(x => x.ByEmployeeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.ByEmployeeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmployeeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByEmployeeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICustomerCommunicationRepository>();
			mock.RepositoryMock.Setup(x => x.ByEmployeeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CustomerCommunication>>(new List<CustomerCommunication>()));
			var service = new CustomerCommunicationService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.CustomerCommunicationModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLCustomerCommunicationMapperMock,
			                                               mock.DALMapperMockFactory.DALCustomerCommunicationMapperMock);

			List<ApiCustomerCommunicationServerResponseModel> response = await service.ByEmployeeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByEmployeeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>667158b49bdcef7b2ffa1ce49034a4bb</Hash>
</Codenesium>*/