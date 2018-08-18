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
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "Services")]
	public partial class SalesTaxRateServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var records = new List<SalesTaxRate>();
			records.Add(new SalesTaxRate());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			List<ApiSalesTaxRateResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var record = new SalesTaxRate();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			ApiSalesTaxRateResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesTaxRate>(null));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			ApiSalesTaxRateResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var model = new ApiSalesTaxRateRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesTaxRate>())).Returns(Task.FromResult(new SalesTaxRate()));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			CreateResponse<ApiSalesTaxRateResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTaxRateRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesTaxRate>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var model = new ApiSalesTaxRateRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesTaxRate>())).Returns(Task.FromResult(new SalesTaxRate()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			UpdateResponse<ApiSalesTaxRateResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesTaxRate>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var model = new ApiSalesTaxRateRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByStateProvinceIDTaxType_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var record = new SalesTaxRate();
			mock.RepositoryMock.Setup(x => x.ByStateProvinceIDTaxType(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			ApiSalesTaxRateResponseModel response = await service.ByStateProvinceIDTaxType(default(int), default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByStateProvinceIDTaxType(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByStateProvinceIDTaxType_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			mock.RepositoryMock.Setup(x => x.ByStateProvinceIDTaxType(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<SalesTaxRate>(null));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			ApiSalesTaxRateResponseModel response = await service.ByStateProvinceIDTaxType(default(int), default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByStateProvinceIDTaxType(It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>34a66122f8f29f755a43d22c987a2e5f</Hash>
</Codenesium>*/