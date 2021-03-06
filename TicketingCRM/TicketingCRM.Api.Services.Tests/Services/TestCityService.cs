using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "City")]
	[Trait("Area", "Services")]
	public partial class CityServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			var records = new List<City>();
			records.Add(new City());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiCityServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			var record = new City();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			ApiCityServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<City>(null));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			ApiCityServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();

			var model = new ApiCityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<City>())).Returns(Task.FromResult(new City()));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			CreateResponse<ApiCityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CityModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<City>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CityCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			var model = new ApiCityServerRequestModel();
			var validatorMock = new Mock<IApiCityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCityServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			CreateResponse<ApiCityServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CityCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			var model = new ApiCityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<City>())).Returns(Task.FromResult(new City()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			UpdateResponse<ApiCityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CityModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCityServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<City>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CityUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			var model = new ApiCityServerRequestModel();
			var validatorMock = new Mock<IApiCityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCityServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			UpdateResponse<ApiCityServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCityServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CityUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			var model = new ApiCityServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CityModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CityDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			var model = new ApiCityServerRequestModel();
			var validatorMock = new Mock<IApiCityServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CityDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByProvinceId_Exists()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			var records = new List<City>();
			records.Add(new City());
			mock.RepositoryMock.Setup(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiCityServerResponseModel> response = await service.ByProvinceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProvinceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			mock.RepositoryMock.Setup(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<City>>(new List<City>()));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiCityServerResponseModel> response = await service.ByProvinceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProvinceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventsByCityId_Exists()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			var records = new List<Event>();
			records.Add(new Event());
			mock.RepositoryMock.Setup(x => x.EventsByCityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventServerResponseModel> response = await service.EventsByCityId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByCityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventsByCityId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICityService, ICityRepository>();
			mock.RepositoryMock.Setup(x => x.EventsByCityId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
			var service = new CityService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.CityModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALCityMapperMock,
			                              mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventServerResponseModel> response = await service.EventsByCityId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByCityId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>1e8d61acb62f6ba7ec43cee312960815</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/