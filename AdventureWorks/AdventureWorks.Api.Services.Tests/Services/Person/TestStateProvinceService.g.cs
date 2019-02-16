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
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "StateProvince")]
	[Trait("Area", "Services")]
	public partial class StateProvinceServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var records = new List<StateProvince>();
			records.Add(new StateProvince());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			List<ApiStateProvinceServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var record = new StateProvince();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ApiStateProvinceServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<StateProvince>(null));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ApiStateProvinceServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var model = new ApiStateProvinceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<StateProvince>())).Returns(Task.FromResult(new StateProvince()));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			CreateResponse<ApiStateProvinceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStateProvinceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<StateProvince>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StateProvinceCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var model = new ApiStateProvinceServerRequestModel();
			var validatorMock = new Mock<IApiStateProvinceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			CreateResponse<ApiStateProvinceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStateProvinceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StateProvinceCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var model = new ApiStateProvinceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<StateProvince>())).Returns(Task.FromResult(new StateProvince()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			UpdateResponse<ApiStateProvinceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<StateProvince>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StateProvinceUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var model = new ApiStateProvinceServerRequestModel();
			var validatorMock = new Mock<IApiStateProvinceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new StateProvince()));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			UpdateResponse<ApiStateProvinceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStateProvinceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StateProvinceUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var model = new ApiStateProvinceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StateProvinceDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var model = new ApiStateProvinceServerRequestModel();
			var validatorMock = new Mock<IApiStateProvinceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StateProvinceDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var record = new StateProvince();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ApiStateProvinceServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<StateProvince>(null));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ApiStateProvinceServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var record = new StateProvince();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ApiStateProvinceServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<StateProvince>(null));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ApiStateProvinceServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByStateProvinceCodeCountryRegionCode_Exists()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var record = new StateProvince();
			mock.RepositoryMock.Setup(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ApiStateProvinceServerResponseModel response = await service.ByStateProvinceCodeCountryRegionCode("test_value", "test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByStateProvinceCodeCountryRegionCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<StateProvince>(null));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			ApiStateProvinceServerResponseModel response = await service.ByStateProvinceCodeCountryRegionCode("test_value", "test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByStateProvinceCodeCountryRegionCode(It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void AddressesByStateProvinceID_Exists()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			var records = new List<Address>();
			records.Add(new Address());
			mock.RepositoryMock.Setup(x => x.AddressesByStateProvinceID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			List<ApiAddressServerResponseModel> response = await service.AddressesByStateProvinceID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.AddressesByStateProvinceID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void AddressesByStateProvinceID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStateProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.AddressesByStateProvinceID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Address>>(new List<Address>()));
			var service = new StateProvinceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.StateProvinceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALStateProvinceMapperMock,
			                                       mock.DALMapperMockFactory.DALAddressMapperMock);

			List<ApiAddressServerResponseModel> response = await service.AddressesByStateProvinceID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.AddressesByStateProvinceID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>de091c84ff18bd74097158e75b1d2d06</Hash>
</Codenesium>*/