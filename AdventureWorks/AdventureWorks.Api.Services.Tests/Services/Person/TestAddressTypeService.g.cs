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
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

			List<ApiAddressTypeServerResponseModel> response = await service.All();

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
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

			ApiAddressTypeServerResponseModel response = await service.Get(default(int));

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
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

			ApiAddressTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var model = new ApiAddressTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AddressType>())).Returns(Task.FromResult(new AddressType()));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

			CreateResponse<ApiAddressTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAddressTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<AddressType>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var model = new ApiAddressTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AddressType>())).Returns(Task.FromResult(new AddressType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AddressType()));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

			UpdateResponse<ApiAddressTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAddressTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<AddressType>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var model = new ApiAddressTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

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
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

			ApiAddressTypeServerResponseModel response = await service.ByName("test_value");

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
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

			ApiAddressTypeServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			var record = new AddressType();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

			ApiAddressTypeServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IAddressTypeRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<AddressType>(null));
			var service = new AddressTypeService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.AddressTypeModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLAddressTypeMapperMock,
			                                     mock.DALMapperMockFactory.DALAddressTypeMapperMock);

			ApiAddressTypeServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}
	}
}

/*<Codenesium>
    <Hash>26fe1b236e28e88654764d6c0e847d85</Hash>
</Codenesium>*/