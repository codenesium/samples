using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Country")]
	[Trait("Area", "Services")]
	public partial class CountryServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			var records = new List<Country>();
			records.Add(new Country());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			List<ApiCountryServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			var record = new Country();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			ApiCountryServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			ApiCountryServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();

			var model = new ApiCountryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Country>())).Returns(Task.FromResult(new Country()));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			CreateResponse<ApiCountryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Country>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			var validatorMock = new Mock<IApiCountryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCountryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			CreateResponse<ApiCountryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCountryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Country>())).Returns(Task.FromResult(new Country()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			UpdateResponse<ApiCountryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Country>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			var validatorMock = new Mock<IApiCountryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Country()));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			UpdateResponse<ApiCountryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCountryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CountryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			var model = new ApiCountryServerRequestModel();
			var validatorMock = new Mock<IApiCountryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CountryDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CountryRequirementsByCountryId_Exists()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			var records = new List<CountryRequirement>();
			records.Add(new CountryRequirement());
			mock.RepositoryMock.Setup(x => x.CountryRequirementsByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			List<ApiCountryRequirementServerResponseModel> response = await service.CountryRequirementsByCountryId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CountryRequirementsByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CountryRequirementsByCountryId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			mock.RepositoryMock.Setup(x => x.CountryRequirementsByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CountryRequirement>>(new List<CountryRequirement>()));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			List<ApiCountryRequirementServerResponseModel> response = await service.CountryRequirementsByCountryId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CountryRequirementsByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void DestinationsByCountryId_Exists()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			var records = new List<Destination>();
			records.Add(new Destination());
			mock.RepositoryMock.Setup(x => x.DestinationsByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			List<ApiDestinationServerResponseModel> response = await service.DestinationsByCountryId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.DestinationsByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void DestinationsByCountryId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICountryService, ICountryRepository>();
			mock.RepositoryMock.Setup(x => x.DestinationsByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Destination>>(new List<Destination>()));
			var service = new CountryService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CountryModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALCountryMapperMock,
			                                 mock.DALMapperMockFactory.DALCountryRequirementMapperMock,
			                                 mock.DALMapperMockFactory.DALDestinationMapperMock);

			List<ApiDestinationServerResponseModel> response = await service.DestinationsByCountryId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.DestinationsByCountryId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>de2fbe62b0c13f10e59ba9d75dd22d4e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/