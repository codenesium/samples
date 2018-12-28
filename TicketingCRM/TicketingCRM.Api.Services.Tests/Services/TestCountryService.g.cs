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
	[Trait("Table", "Country")]
	[Trait("Area", "Services")]
	public partial class CountryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			var records = new List<Country>();
			records.Add(new Country());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			List<ApiCountryServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			var record = new Country();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			ApiCountryServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			ApiCountryServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Country>())).Returns(Task.FromResult(new Country()));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			CreateResponse<ApiCountryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Country>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			var validatorMock = new Mock<IApiCountryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			CreateResponse<ApiCountryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Country>())).Returns(Task.FromResult(new Country()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			UpdateResponse<ApiCountryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Country>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			var validatorMock = new Mock<IApiCountryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			UpdateResponse<ApiCountryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			var validatorMock = new Mock<IApiCountryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ProvincesByCountryId_Exists()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			var records = new List<Province>();
			records.Add(new Province());
			mock.RepositoryMock.Setup(x => x.ProvincesByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			List<ApiProvinceServerResponseModel> response = await service.ProvincesByCountryId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ProvincesByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ProvincesByCountryId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICountryRepository>();
			mock.RepositoryMock.Setup(x => x.ProvincesByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Province>>(new List<Province>()));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.BOLMapperMockFactory.BOLProvinceMapperMock,
			                                 mock.DALMapperMockFactory.DALProvinceMapperMock);

			List<ApiProvinceServerResponseModel> response = await service.ProvincesByCountryId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ProvincesByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>caf9b49638869d844a6e45df97a40128</Hash>
</Codenesium>*/