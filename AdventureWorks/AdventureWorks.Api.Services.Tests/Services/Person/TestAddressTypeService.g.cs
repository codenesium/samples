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
	[Trait("Table", "AddressType")]
	[Trait("Area", "Services")]
	public partial class AddressTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var records = new List<AddressType>();
			records.Add(new AddressType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			List<ApiAddressTypeResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var record = new AddressType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ApiAddressTypeResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<AddressType>(null));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ApiAddressTypeResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var model = new ApiAddressTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AddressType>())).Returns(Task.FromResult(new AddressType()));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			CreateResponse<ApiAddressTypeResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAddressTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<AddressType>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var model = new ApiAddressTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AddressType>())).Returns(Task.FromResult(new AddressType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AddressType()));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			UpdateResponse<ApiAddressTypeResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<AddressType>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var model = new ApiAddressTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var record = new AddressType();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ApiAddressTypeResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<AddressType>(null));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			ApiAddressTypeResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void BusinessEntityAddresses_Exists()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var records = new List<BusinessEntityAddress>();
			records.Add(new BusinessEntityAddress());
			mock.RepositoryMock.Setup(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			List<ApiBusinessEntityAddressResponseModel> response = await service.BusinessEntityAddresses(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BusinessEntityAddresses_Not_Exists()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			mock.RepositoryMock.Setup(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<BusinessEntityAddress>>(new List<BusinessEntityAddress>()));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock,
			                                     mock.BOLMapperMockFactory.BOLBusinessEntityAddressMapperMock,
			                                     mock.DALMapperMockFactory.DALBusinessEntityAddressMapperMock);

			List<ApiBusinessEntityAddressResponseModel> response = await service.BusinessEntityAddresses(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BusinessEntityAddresses(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>240e82f71b5369f795b97307e5973f06</Hash>
</Codenesium>*/