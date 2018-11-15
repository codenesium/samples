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
	[Trait("Table", "Vendor")]
	[Trait("Area", "Services")]
	public partial class VendorServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			var records = new List<Vendor>();
			records.Add(new Vendor());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiVendorServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			var record = new Vendor();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiVendorServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Vendor>(null));
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiVendorServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			var model = new ApiVendorServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vendor>())).Returns(Task.FromResult(new Vendor()));
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			CreateResponse<ApiVendorServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VendorModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiVendorServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Vendor>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			var model = new ApiVendorServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Vendor>())).Returns(Task.FromResult(new Vendor()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Vendor()));
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			UpdateResponse<ApiVendorServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.VendorModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVendorServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Vendor>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			var model = new ApiVendorServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.VendorModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByAccountNumber_Exists()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			var record = new Vendor();
			mock.RepositoryMock.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiVendorServerResponseModel response = await service.ByAccountNumber("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByAccountNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void ByAccountNumber_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			mock.RepositoryMock.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Vendor>(null));
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			ApiVendorServerResponseModel response = await service.ByAccountNumber("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByAccountNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void PurchaseOrderHeadersByVendorID_Exists()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			var records = new List<PurchaseOrderHeader>();
			records.Add(new PurchaseOrderHeader());
			mock.RepositoryMock.Setup(x => x.PurchaseOrderHeadersByVendorID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await service.PurchaseOrderHeadersByVendorID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PurchaseOrderHeadersByVendorID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PurchaseOrderHeadersByVendorID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IVendorRepository>();
			mock.RepositoryMock.Setup(x => x.PurchaseOrderHeadersByVendorID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PurchaseOrderHeader>>(new List<PurchaseOrderHeader>()));
			var service = new VendorService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.VendorModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLVendorMapperMock,
			                                mock.DALMapperMockFactory.DALVendorMapperMock,
			                                mock.BOLMapperMockFactory.BOLPurchaseOrderHeaderMapperMock,
			                                mock.DALMapperMockFactory.DALPurchaseOrderHeaderMapperMock);

			List<ApiPurchaseOrderHeaderServerResponseModel> response = await service.PurchaseOrderHeadersByVendorID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PurchaseOrderHeadersByVendorID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>2abcb3f81685921294282ddca8857da9</Hash>
</Codenesium>*/