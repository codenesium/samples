using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Address")]
	[Trait("Area", "Services")]
	public partial class AddressServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var records = new List<Address>();
			records.Add(new Address());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiAddressServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var record = new Address();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			ApiAddressServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Address>(null));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			ApiAddressServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var model = new ApiAddressServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Address>())).Returns(Task.FromResult(new Address()));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiAddressServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AddressModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAddressServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Address>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AddressCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var model = new ApiAddressServerRequestModel();
			var validatorMock = new Mock<IApiAddressServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAddressServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiAddressServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAddressServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AddressCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var model = new ApiAddressServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Address>())).Returns(Task.FromResult(new Address()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiAddressServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.AddressModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Address>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AddressUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var model = new ApiAddressServerRequestModel();
			var validatorMock = new Mock<IApiAddressServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiAddressServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AddressUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var model = new ApiAddressServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AddressModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AddressDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var model = new ApiAddressServerRequestModel();
			var validatorMock = new Mock<IApiAddressServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<AddressDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CallsByAddressId_Exists()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var records = new List<Call>();
			records.Add(new Call());
			mock.RepositoryMock.Setup(x => x.CallsByAddressId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByAddressId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByAddressId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CallsByAddressId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			mock.RepositoryMock.Setup(x => x.CallsByAddressId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Call>>(new List<Call>()));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByAddressId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByAddressId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>9f262c2b4861c78e02e6a300cbb9e76e</Hash>
</Codenesium>*/