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
	[Trait("Table", "ProductReview")]
	[Trait("Area", "Services")]
	public partial class ProductReviewServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductReviewRepository>();
			var records = new List<ProductReview>();
			records.Add(new ProductReview());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductReviewService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                       mock.DALMapperMockFactory.DALProductReviewMapperMock);

			List<ApiProductReviewServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductReviewRepository>();
			var record = new ProductReview();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductReviewService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                       mock.DALMapperMockFactory.DALProductReviewMapperMock);

			ApiProductReviewServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductReviewRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductReview>(null));
			var service = new ProductReviewService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                       mock.DALMapperMockFactory.DALProductReviewMapperMock);

			ApiProductReviewServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProductReviewRepository>();
			var model = new ApiProductReviewServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductReview>())).Returns(Task.FromResult(new ProductReview()));
			var service = new ProductReviewService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                       mock.DALMapperMockFactory.DALProductReviewMapperMock);

			CreateResponse<ApiProductReviewServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductReviewServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductReview>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProductReviewRepository>();
			var model = new ApiProductReviewServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductReview>())).Returns(Task.FromResult(new ProductReview()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductReview()));
			var service = new ProductReviewService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                       mock.DALMapperMockFactory.DALProductReviewMapperMock);

			UpdateResponse<ApiProductReviewServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductReviewServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductReview>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProductReviewRepository>();
			var model = new ApiProductReviewServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductReviewService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                       mock.DALMapperMockFactory.DALProductReviewMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductIDReviewerName_Exists()
		{
			var mock = new ServiceMockFacade<IProductReviewRepository>();
			var records = new List<ProductReview>();
			records.Add(new ProductReview());
			mock.RepositoryMock.Setup(x => x.ByProductIDReviewerName(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductReviewService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                       mock.DALMapperMockFactory.DALProductReviewMapperMock);

			List<ApiProductReviewServerResponseModel> response = await service.ByProductIDReviewerName(default(int), "test_value");

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductIDReviewerName(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductIDReviewerName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProductReviewRepository>();
			mock.RepositoryMock.Setup(x => x.ByProductIDReviewerName(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<ProductReview>>(new List<ProductReview>()));
			var service = new ProductReviewService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.ProductReviewModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLProductReviewMapperMock,
			                                       mock.DALMapperMockFactory.DALProductReviewMapperMock);

			List<ApiProductReviewServerResponseModel> response = await service.ByProductIDReviewerName(default(int), "test_value");

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductIDReviewerName(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>42bcd351928f3d84544b2afcd09a1fb4</Hash>
</Codenesium>*/