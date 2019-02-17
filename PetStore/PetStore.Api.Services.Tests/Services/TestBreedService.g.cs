using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "Services")]
	public partial class BreedServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var records = new List<Breed>();
			records.Add(new Breed());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiBreedServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var record = new Breed();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			ApiBreedServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Breed>(null));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			ApiBreedServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var model = new ApiBreedServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Breed>())).Returns(Task.FromResult(new Breed()));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			CreateResponse<ApiBreedServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.BreedModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBreedServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Breed>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BreedCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var model = new ApiBreedServerRequestModel();
			var validatorMock = new Mock<IApiBreedServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBreedServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			CreateResponse<ApiBreedServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBreedServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BreedCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var model = new ApiBreedServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Breed>())).Returns(Task.FromResult(new Breed()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Breed()));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			UpdateResponse<ApiBreedServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.BreedModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBreedServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Breed>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BreedUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var model = new ApiBreedServerRequestModel();
			var validatorMock = new Mock<IApiBreedServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBreedServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Breed()));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			UpdateResponse<ApiBreedServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBreedServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BreedUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var model = new ApiBreedServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.BreedModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BreedDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var model = new ApiBreedServerRequestModel();
			var validatorMock = new Mock<IApiBreedServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BreedDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void BySpeciesId_Exists()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var records = new List<Breed>();
			records.Add(new Breed());
			mock.RepositoryMock.Setup(x => x.BySpeciesId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiBreedServerResponseModel> response = await service.BySpeciesId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.BySpeciesId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void BySpeciesId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			mock.RepositoryMock.Setup(x => x.BySpeciesId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Breed>>(new List<Breed>()));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiBreedServerResponseModel> response = await service.BySpeciesId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.BySpeciesId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PetsByBreedId_Exists()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var records = new List<Pet>();
			records.Add(new Pet());
			mock.RepositoryMock.Setup(x => x.PetsByBreedId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPetServerResponseModel> response = await service.PetsByBreedId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PetsByBreedId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PetsByBreedId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			mock.RepositoryMock.Setup(x => x.PetsByBreedId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Pet>>(new List<Pet>()));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPetServerResponseModel> response = await service.PetsByBreedId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PetsByBreedId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6e024fa4ff008ee58ac79740b37173f0</Hash>
</Codenesium>*/