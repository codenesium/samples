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
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "Services")]
	public partial class ProductPhotoServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var records = new List<ProductPhoto>();
			records.Add(new ProductPhoto());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			List<ApiProductPhotoResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var record = new ProductPhoto();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ApiProductPhotoResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductPhoto>(null));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ApiProductPhotoResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var model = new ApiProductPhotoRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductPhoto>())).Returns(Task.FromResult(new ProductPhoto()));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			CreateResponse<ApiProductPhotoResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductPhotoRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductPhoto>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var model = new ApiProductPhotoRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductPhoto>())).Returns(Task.FromResult(new ProductPhoto()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductPhoto()));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			UpdateResponse<ApiProductPhotoResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductPhotoRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductPhoto>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var model = new ApiProductPhotoRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ProductProductPhotoes_Exists()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			var records = new List<ProductProductPhoto>();
			records.Add(new ProductProductPhoto());
			mock.RepositoryMock.Setup(x => x.ProductProductPhotoes(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			List<ApiProductProductPhotoResponseModel> response = await service.ProductProductPhotoes(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductProductPhotoes(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProductProductPhotoes_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductPhotoRepository>();
			mock.RepositoryMock.Setup(x => x.ProductProductPhotoes(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductProductPhoto>>(new List<ProductProductPhoto>()));
			var service = new ProductPhotoService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.ProductPhotoModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductPhotoMapperMock,
			                                      mock.BOLMapperMockFactory.BOLProductProductPhotoMapperMock,
			                                      mock.DALMapperMockFactory.DALProductProductPhotoMapperMock);

			List<ApiProductProductPhotoResponseModel> response = await service.ProductProductPhotoes(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProductProductPhotoes(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>e72544b73f91d02ea54001a89ec62d48</Hash>
</Codenesium>*/