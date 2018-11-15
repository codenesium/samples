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
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "Services")]
	public partial class ProductDescriptionServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var records = new List<ProductDescription>();
			records.Add(new ProductDescription());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			List<ApiProductDescriptionServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var record = new ProductDescription();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ApiProductDescriptionServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductDescription>(null));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ApiProductDescriptionServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var model = new ApiProductDescriptionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductDescription>())).Returns(Task.FromResult(new ProductDescription()));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			CreateResponse<ApiProductDescriptionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductDescriptionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductDescription>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var model = new ApiProductDescriptionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductDescription>())).Returns(Task.FromResult(new ProductDescription()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductDescription()));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			UpdateResponse<ApiProductDescriptionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductDescriptionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductDescription>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var model = new ApiProductDescriptionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			var record = new ProductDescription();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ApiProductDescriptionServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductDescriptionRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<ProductDescription>(null));
			var service = new ProductDescriptionService(mock.LoggerMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.ProductDescriptionModelValidatorMock.Object,
			                                            mock.BOLMapperMockFactory.BOLProductDescriptionMapperMock,
			                                            mock.DALMapperMockFactory.DALProductDescriptionMapperMock);

			ApiProductDescriptionServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}
	}
}

/*<Codenesium>
    <Hash>45eaf53c484ec15777446b81c49756b7</Hash>
</Codenesium>*/