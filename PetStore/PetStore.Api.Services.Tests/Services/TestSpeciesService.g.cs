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
	[Trait("Table", "Species")]
	[Trait("Area", "Services")]
	public partial class SpeciesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISpeciesRepository>();
			var records = new List<Species>();
			records.Add(new Species());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.BOLMapperMockFactory.BOLPetMapperMock,
			                                 mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiSpeciesServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISpeciesRepository>();
			var record = new Species();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.BOLMapperMockFactory.BOLPetMapperMock,
			                                 mock.DALMapperMockFactory.DALPetMapperMock);

			ApiSpeciesServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISpeciesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Species>(null));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.BOLMapperMockFactory.BOLPetMapperMock,
			                                 mock.DALMapperMockFactory.DALPetMapperMock);

			ApiSpeciesServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISpeciesRepository>();
			var model = new ApiSpeciesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Species>())).Returns(Task.FromResult(new Species()));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.BOLMapperMockFactory.BOLPetMapperMock,
			                                 mock.DALMapperMockFactory.DALPetMapperMock);

			CreateResponse<ApiSpeciesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpeciesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Species>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISpeciesRepository>();
			var model = new ApiSpeciesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Species>())).Returns(Task.FromResult(new Species()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Species()));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.BOLMapperMockFactory.BOLPetMapperMock,
			                                 mock.DALMapperMockFactory.DALPetMapperMock);

			UpdateResponse<ApiSpeciesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpeciesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Species>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISpeciesRepository>();
			var model = new ApiSpeciesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.BOLMapperMockFactory.BOLPetMapperMock,
			                                 mock.DALMapperMockFactory.DALPetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void PetsBySpeciesId_Exists()
		{
			var mock = new ServiceMockFacade<ISpeciesRepository>();
			var records = new List<Pet>();
			records.Add(new Pet());
			mock.RepositoryMock.Setup(x => x.PetsBySpeciesId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.BOLMapperMockFactory.BOLPetMapperMock,
			                                 mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPetServerResponseModel> response = await service.PetsBySpeciesId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PetsBySpeciesId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PetsBySpeciesId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISpeciesRepository>();
			mock.RepositoryMock.Setup(x => x.PetsBySpeciesId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Pet>>(new List<Pet>()));
			var service = new SpeciesService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.SpeciesModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLSpeciesMapperMock,
			                                 mock.DALMapperMockFactory.DALSpeciesMapperMock,
			                                 mock.BOLMapperMockFactory.BOLPetMapperMock,
			                                 mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPetServerResponseModel> response = await service.PetsBySpeciesId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PetsBySpeciesId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6464fcbd12f3b916d9f0ce1f9146d15d</Hash>
</Codenesium>*/