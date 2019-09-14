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
	[Trait("Table", "Province")]
	[Trait("Area", "Services")]
	public partial class ProvinceServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var records = new List<Province>();
			records.Add(new Province());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiProvinceServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var record = new Province();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiProvinceServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			ApiProvinceServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();

			var model = new ApiProvinceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Province>())).Returns(Task.FromResult(new Province()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			CreateResponse<ApiProvinceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProvinceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Province>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProvinceCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var model = new ApiProvinceServerRequestModel();
			var validatorMock = new Mock<IApiProvinceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiProvinceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			CreateResponse<ApiProvinceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProvinceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProvinceCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var model = new ApiProvinceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Province>())).Returns(Task.FromResult(new Province()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			UpdateResponse<ApiProvinceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProvinceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Province>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProvinceUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var model = new ApiProvinceServerRequestModel();
			var validatorMock = new Mock<IApiProvinceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProvinceServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			UpdateResponse<ApiProvinceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiProvinceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProvinceUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var model = new ApiProvinceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProvinceDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var model = new ApiProvinceServerRequestModel();
			var validatorMock = new Mock<IApiProvinceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ProvinceDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByCountryId_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var records = new List<Province>();
			records.Add(new Province());
			mock.RepositoryMock.Setup(x => x.ByCountryId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiProvinceServerResponseModel> response = await service.ByCountryId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCountryId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByCountryId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.ByCountryId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Province>>(new List<Province>()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiProvinceServerResponseModel> response = await service.ByCountryId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCountryId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CitiesByProvinceId_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var records = new List<City>();
			records.Add(new City());
			mock.RepositoryMock.Setup(x => x.CitiesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiCityServerResponseModel> response = await service.CitiesByProvinceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CitiesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CitiesByProvinceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.CitiesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<City>>(new List<City>()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiCityServerResponseModel> response = await service.CitiesByProvinceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CitiesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VenuesByProvinceId_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			var records = new List<Venue>();
			records.Add(new Venue());
			mock.RepositoryMock.Setup(x => x.VenuesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.VenuesByProvinceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.VenuesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void VenuesByProvinceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProvinceService, IProvinceRepository>();
			mock.RepositoryMock.Setup(x => x.VenuesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Venue>>(new List<Venue>()));
			var service = new ProvinceService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.ProvinceModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALProvinceMapperMock,
			                                  mock.DALMapperMockFactory.DALCityMapperMock,
			                                  mock.DALMapperMockFactory.DALVenueMapperMock);

			List<ApiVenueServerResponseModel> response = await service.VenuesByProvinceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.VenuesByProvinceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>9fb6f9c50489ea0e1cb1305bd291f4fa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/