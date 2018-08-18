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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			List<ApiAddressResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var record = new Address();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ApiAddressResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Address>(null));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ApiAddressResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var model = new ApiAddressRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Address>())).Returns(Task.FromResult(new Address()));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			CreateResponse<ApiAddressResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AddressModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAddressRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Address>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var model = new ApiAddressRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Address>())).Returns(Task.FromResult(new Address()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Address()));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			UpdateResponse<ApiAddressResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AddressModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Address>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var model = new ApiAddressRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AddressModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Exists()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var record = new Address();
			mock.RepositoryMock.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ApiAddressResponseModel response = await service.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(default(string), default(string), default(string), default(int), default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByAddressLine1AddressLine2CityStateProvinceIDPostalCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			mock.RepositoryMock.Setup(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Address>(null));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ApiAddressResponseModel response = await service.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(default(string), default(string), default(string), default(int), default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByStateProvinceID_Exists()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var records = new List<Address>();
			records.Add(new Address());
			mock.RepositoryMock.Setup(x => x.ByStateProvinceID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			List<ApiAddressResponseModel> response = await service.ByStateProvinceID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByStateProvinceID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByStateProvinceID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			mock.RepositoryMock.Setup(x => x.ByStateProvinceID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Address>>(new List<Address>()));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			List<ApiAddressResponseModel> response = await service.ByStateProvinceID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByStateProvinceID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BusinessEntityAddresses_Exists()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			var records = new List<BusinessEntityAddress>();
			records.Add(new BusinessEntityAddress());
			mock.RepositoryMock.Setup(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			List<ApiBusinessEntityAddressResponseModel> response = await service.BusinessEntityAddresses(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BusinessEntityAddresses_Not_Exists()
		{
			var mock = new ServiceMockFacade<IAddressRepository>();
			mock.RepositoryMock.Setup(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityAddress>>(new List<BusinessEntityAddress>()));
			var service = new AddressService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.AddressModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALAddressMapperMock,
			                                 mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                 mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			List<ApiBusinessEntityAddressResponseModel> response = await service.BusinessEntityAddresses(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b12c279e18d64eb5228a7682c814ffa3</Hash>
</Codenesium>*/