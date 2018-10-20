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
	[Trait("Table", "SpecialOfferProduct")]
	[Trait("Area", "Services")]
	public partial class SpecialOfferProductServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
			var records = new List<SpecialOfferProduct>();
			records.Add(new SpecialOfferProduct());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpecialOfferProductService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
			                                             mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock);

			List<ApiSpecialOfferProductResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
			var record = new SpecialOfferProduct();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpecialOfferProductService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
			                                             mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock);

			ApiSpecialOfferProductResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(null));
			var service = new SpecialOfferProductService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
			                                             mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock);

			ApiSpecialOfferProductResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
			var model = new ApiSpecialOfferProductRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpecialOfferProduct>())).Returns(Task.FromResult(new SpecialOfferProduct()));
			var service = new SpecialOfferProductService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
			                                             mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock);

			CreateResponse<ApiSpecialOfferProductResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpecialOfferProductRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SpecialOfferProduct>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
			var model = new ApiSpecialOfferProductRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpecialOfferProduct>())).Returns(Task.FromResult(new SpecialOfferProduct()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpecialOfferProduct()));
			var service = new SpecialOfferProductService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
			                                             mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock);

			UpdateResponse<ApiSpecialOfferProductResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpecialOfferProductRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SpecialOfferProduct>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISpecialOfferProductRepository>();
			var model = new ApiSpecialOfferProductRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpecialOfferProductService(mock.LoggerMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Object,
			                                             mock.BOLMapperMockFactory.BOLSpecialOfferProductMapperMock,
			                                             mock.DALMapperMockFactory.DALSpecialOfferProductMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpecialOfferProductModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c18a6198550741c896ab61fbd30e6aa0</Hash>
</Codenesium>*/