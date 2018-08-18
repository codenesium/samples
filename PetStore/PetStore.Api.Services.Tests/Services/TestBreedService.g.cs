using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBreedMapperMock,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.BOLMapperMockFactory.BOLPetMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiBreedResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var record = new Breed();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBreedMapperMock,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.BOLMapperMockFactory.BOLPetMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			ApiBreedResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Breed>(null));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBreedMapperMock,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.BOLMapperMockFactory.BOLPetMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			ApiBreedResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var model = new ApiBreedRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Breed>())).Returns(Task.FromResult(new Breed()));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBreedMapperMock,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.BOLMapperMockFactory.BOLPetMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			CreateResponse<ApiBreedResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.BreedModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBreedRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Breed>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var model = new ApiBreedRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Breed>())).Returns(Task.FromResult(new Breed()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Breed()));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBreedMapperMock,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.BOLMapperMockFactory.BOLPetMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			UpdateResponse<ApiBreedResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.BreedModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBreedRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Breed>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var model = new ApiBreedRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBreedMapperMock,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.BOLMapperMockFactory.BOLPetMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.BreedModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Pets_Exists()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			var records = new List<Pet>();
			records.Add(new Pet());
			mock.RepositoryMock.Setup(x => x.Pets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBreedMapperMock,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.BOLMapperMockFactory.BOLPetMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPetResponseModel> response = await service.Pets(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Pets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Pets_Not_Exists()
		{
			var mock = new ServiceMockFacade<IBreedRepository>();
			mock.RepositoryMock.Setup(x => x.Pets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Pet>>(new List<Pet>()));
			var service = new BreedService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.BreedModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLBreedMapperMock,
			                               mock.DALMapperMockFactory.DALBreedMapperMock,
			                               mock.BOLMapperMockFactory.BOLPetMapperMock,
			                               mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPetResponseModel> response = await service.Pets(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Pets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>54b5b88556898bcf71a629958be9a811</Hash>
</Codenesium>*/