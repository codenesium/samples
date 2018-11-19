using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
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

			List<ApiSalesTaxRateServerResponseModel> response = await service.All();

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

			ApiSalesTaxRateServerResponseModel response = await service.Get(default(int));

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

			ApiSalesTaxRateServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var model = new ApiSalesTaxRateServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesTaxRate>())).Returns(Task.FromResult(new SalesTaxRate()));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			CreateResponse<ApiSalesTaxRateServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTaxRateServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesTaxRate>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var model = new ApiSalesTaxRateServerRequestModel();
			var validatorMock = new Mock<IApiSalesTaxRateServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			CreateResponse<ApiSalesTaxRateServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesTaxRateServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var model = new ApiSalesTaxRateServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesTaxRate>())).Returns(Task.FromResult(new SalesTaxRate()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			UpdateResponse<ApiSalesTaxRateServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesTaxRate>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var model = new ApiSalesTaxRateServerRequestModel();
			var validatorMock = new Mock<IApiSalesTaxRateServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			UpdateResponse<ApiSalesTaxRateServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesTaxRateServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var model = new ApiSalesTaxRateServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var model = new ApiSalesTaxRateServerRequestModel();
			var validatorMock = new Mock<IApiSalesTaxRateServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			var record = new SalesTaxRate();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			ApiSalesTaxRateServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISalesTaxRateRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesTaxRate>(null));
			var service = new SalesTaxRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SalesTaxRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLSalesTaxRateMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesTaxRateMapperMock);

			ApiSalesTaxRateServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
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

			ApiSalesTaxRateServerResponseModel response = await service.ByStateProvinceIDTaxType(default(int), default(int));

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

			ApiSalesTaxRateServerResponseModel response = await service.ByStateProvinceIDTaxType(default(int), default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByStateProvinceIDTaxType(It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>fbc2fd669b13f30d62375bd04fa91152</Hash>
</Codenesium>*/