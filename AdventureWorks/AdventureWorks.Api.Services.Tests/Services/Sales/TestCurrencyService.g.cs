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
	[Trait("Table", "Currency")]
	[Trait("Area", "Services")]
	public partial class CurrencyServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			var records = new List<Currency>();
			records.Add(new Currency());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			List<ApiCurrencyServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			var record = new Currency();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			ApiCurrencyServerResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			ApiCurrencyServerResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			var model = new ApiCurrencyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Currency>())).Returns(Task.FromResult(new Currency()));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			CreateResponse<ApiCurrencyServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCurrencyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Currency>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			var model = new ApiCurrencyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Currency>())).Returns(Task.FromResult(new Currency()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			UpdateResponse<ApiCurrencyServerResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCurrencyServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Currency>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			var model = new ApiCurrencyServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			var record = new Currency();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			ApiCurrencyServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			ApiCurrencyServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void CurrencyRatesByFromCurrencyCode_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			var records = new List<CurrencyRate>();
			records.Add(new CurrencyRate());
			mock.RepositoryMock.Setup(x => x.CurrencyRatesByFromCurrencyCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			List<ApiCurrencyRateServerResponseModel> response = await service.CurrencyRatesByFromCurrencyCode(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CurrencyRatesByFromCurrencyCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CurrencyRatesByFromCurrencyCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			mock.RepositoryMock.Setup(x => x.CurrencyRatesByFromCurrencyCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CurrencyRate>>(new List<CurrencyRate>()));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			List<ApiCurrencyRateServerResponseModel> response = await service.CurrencyRatesByFromCurrencyCode(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CurrencyRatesByFromCurrencyCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CurrencyRatesByToCurrencyCode_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			var records = new List<CurrencyRate>();
			records.Add(new CurrencyRate());
			mock.RepositoryMock.Setup(x => x.CurrencyRatesByToCurrencyCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			List<ApiCurrencyRateServerResponseModel> response = await service.CurrencyRatesByToCurrencyCode(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CurrencyRatesByToCurrencyCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CurrencyRatesByToCurrencyCode_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICurrencyRepository>();
			mock.RepositoryMock.Setup(x => x.CurrencyRatesByToCurrencyCode(default(string), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CurrencyRate>>(new List<CurrencyRate>()));
			var service = new CurrencyService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CurrencyModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCurrencyMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyMapperMock,
			                                  mock.BOLMapperMockFactory.BOLCurrencyRateMapperMock,
			                                  mock.DALMapperMockFactory.DALCurrencyRateMapperMock);

			List<ApiCurrencyRateServerResponseModel> response = await service.CurrencyRatesByToCurrencyCode(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CurrencyRatesByToCurrencyCode(default(string), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d42afc7a0b8647e5e682871d187c0599</Hash>
</Codenesium>*/