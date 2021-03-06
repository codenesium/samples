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
	[Trait("Table", "Species")]
	[Trait("Area", "Services")]
	public partial class SpeciesServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();
			var records = new List<Species>();
			records.Add(new Species());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			List<ApiSpeciesServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();
			var record = new Species();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			ApiSpeciesServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Species>(null));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			ApiSpeciesServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();

			var model = new ApiSpeciesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Species>())).Returns(Task.FromResult(new Species()));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			CreateResponse<ApiSpeciesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpeciesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Species>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpeciesCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();
			var model = new ApiSpeciesServerRequestModel();
			var validatorMock = new Mock<IApiSpeciesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpeciesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			CreateResponse<ApiSpeciesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpeciesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpeciesCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();
			var model = new ApiSpeciesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Species>())).Returns(Task.FromResult(new Species()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			UpdateResponse<ApiSpeciesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpeciesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Species>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpeciesUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();
			var model = new ApiSpeciesServerRequestModel();
			var validatorMock = new Mock<IApiSpeciesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpeciesServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			UpdateResponse<ApiSpeciesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpeciesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpeciesUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();
			var model = new ApiSpeciesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpeciesDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();
			var model = new ApiSpeciesServerRequestModel();
			var validatorMock = new Mock<IApiSpeciesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpeciesDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void BreedsBySpeciesId_Exists()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();
			var records = new List<Breed>();
			records.Add(new Breed());
			mock.RepositoryMock.Setup(x => x.BreedsBySpeciesId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			List<ApiBreedServerResponseModel> response = await service.BreedsBySpeciesId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BreedsBySpeciesId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BreedsBySpeciesId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISpeciesService, ISpeciesRepository>();
			mock.RepositoryMock.Setup(x => x.BreedsBySpeciesId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Breed>>(new List<Breed>()));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALBreedMapperMock);

			List<ApiBreedServerResponseModel> response = await service.BreedsBySpeciesId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BreedsBySpeciesId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>56fb4462e25c62b53e8cc5fa806fe4f4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/