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
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "Services")]
	public partial class CurrencyRateServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var records = new List<CurrencyRate>();
			records.Add(new CurrencyRate());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiCurrencyRateServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var record = new CurrencyRate();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCurrencyRateServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CurrencyRate>(null));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCurrencyRateServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var model = new ApiCurrencyRateServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CurrencyRate>())).Returns(Task.FromResult(new CurrencyRate()));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			CreateResponse<ApiCurrencyRateServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCurrencyRateServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CurrencyRate>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var model = new ApiCurrencyRateServerRequestModel();
			var validatorMock = new Mock<IApiCurrencyRateServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			CreateResponse<ApiCurrencyRateServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCurrencyRateServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var model = new ApiCurrencyRateServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CurrencyRate>())).Returns(Task.FromResult(new CurrencyRate()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			UpdateResponse<ApiCurrencyRateServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CurrencyRate>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var model = new ApiCurrencyRateServerRequestModel();
			var validatorMock = new Mock<IApiCurrencyRateServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			UpdateResponse<ApiCurrencyRateServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCurrencyRateServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var model = new ApiCurrencyRateServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var model = new ApiCurrencyRateServerRequestModel();
			var validatorMock = new Mock<IApiCurrencyRateServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByCurrencyRateDateFromCurrencyCodeToCurrencyCode_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var record = new CurrencyRate();
			mock.RepositoryMock.Setup(x => x.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCurrencyRateServerResponseModel response = await service.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(default(DateTime), "test_value", "test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByCurrencyRateDateFromCurrencyCodeToCurrencyCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			mock.RepositoryMock.Setup(x => x.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<CurrencyRate>(null));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCurrencyRateServerResponseModel response = await service.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(default(DateTime), "test_value", "test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void SalesOrderHeadersByCurrencyRateID_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			var records = new List<SalesOrderHeader>();
			records.Add(new SalesOrderHeader());
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByCurrencyRateID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByCurrencyRateID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByCurrencyRateID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesOrderHeadersByCurrencyRateID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRateRepository>();
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByCurrencyRateID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderHeader>>(new List<SalesOrderHeader>()));
			var service = new CurrencyRateService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.CurrencyRateModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                      mock.DALMapperMockFactory.DALCurrencyRateMapperMock,
			                                      mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                      mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByCurrencyRateID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByCurrencyRateID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>ac8a0edd585a6d6becb160cb1aeabdc2</Hash>
</Codenesium>*/