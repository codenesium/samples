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
	[Trait("Table", "ProductModelIllustration")]
	[Trait("Area", "Services")]
	public partial class ProductModelIllustrationServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProductModelIllustrationRepository>();
			var records = new List<ProductModelIllustration>();
			records.Add(new ProductModelIllustration());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProductModelIllustrationService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.ProductModelIllustrationModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
			                                                  mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock);

			List<ApiProductModelIllustrationResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProductModelIllustrationRepository>();
			var record = new ProductModelIllustration();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProductModelIllustrationService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.ProductModelIllustrationModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
			                                                  mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock);

			ApiProductModelIllustrationResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProductModelIllustrationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ProductModelIllustration>(null));
			var service = new ProductModelIllustrationService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.ProductModelIllustrationModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
			                                                  mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock);

			ApiProductModelIllustrationResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProductModelIllustrationRepository>();
			var model = new ApiProductModelIllustrationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductModelIllustration>())).Returns(Task.FromResult(new ProductModelIllustration()));
			var service = new ProductModelIllustrationService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.ProductModelIllustrationModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
			                                                  mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock);

			CreateResponse<ApiProductModelIllustrationResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductModelIllustrationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProductModelIllustrationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProductModelIllustration>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProductModelIllustrationRepository>();
			var model = new ApiProductModelIllustrationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProductModelIllustration>())).Returns(Task.FromResult(new ProductModelIllustration()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ProductModelIllustration()));
			var service = new ProductModelIllustrationService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.ProductModelIllustrationModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
			                                                  mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock);

			UpdateResponse<ApiProductModelIllustrationResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProductModelIllustrationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProductModelIllustrationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProductModelIllustration>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProductModelIllustrationRepository>();
			var model = new ApiProductModelIllustrationRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProductModelIllustrationService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.ProductModelIllustrationModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLProductModelIllustrationMapperMock,
			                                                  mock.DALMapperMockFactory.DALProductModelIllustrationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProductModelIllustrationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>4e0c191818d526c4d2c17c1b2d15b231</Hash>
</Codenesium>*/