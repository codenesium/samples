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
	[Trait("Table", "Pen")]
	[Trait("Area", "Services")]
	public partial class PenServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var records = new List<Pen>();
			records.Add(new Pen());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPenMapperMock,
			                             mock.DALMapperMockFactory.DALPenMapperMock,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPenServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var record = new Pen();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPenMapperMock,
			                             mock.DALMapperMockFactory.DALPenMapperMock,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			ApiPenServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Pen>(null));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPenMapperMock,
			                             mock.DALMapperMockFactory.DALPenMapperMock,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			ApiPenServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var model = new ApiPenServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pen>())).Returns(Task.FromResult(new Pen()));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPenMapperMock,
			                             mock.DALMapperMockFactory.DALPenMapperMock,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			CreateResponse<ApiPenServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PenModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPenServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Pen>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var model = new ApiPenServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pen>())).Returns(Task.FromResult(new Pen()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPenMapperMock,
			                             mock.DALMapperMockFactory.DALPenMapperMock,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			UpdateResponse<ApiPenServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PenModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPenServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Pen>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var model = new ApiPenServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPenMapperMock,
			                             mock.DALMapperMockFactory.DALPenMapperMock,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PenModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void PetsByPenId_Exists()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var records = new List<Pet>();
			records.Add(new Pet());
			mock.RepositoryMock.Setup(x => x.PetsByPenId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPenMapperMock,
			                             mock.DALMapperMockFactory.DALPenMapperMock,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPetServerResponseModel> response = await service.PetsByPenId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PetsByPenId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PetsByPenId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			mock.RepositoryMock.Setup(x => x.PetsByPenId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Pet>>(new List<Pet>()));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPenMapperMock,
			                             mock.DALMapperMockFactory.DALPenMapperMock,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPetServerResponseModel> response = await service.PetsByPenId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PetsByPenId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>56722de7931dac7aa3a96ad2603bb51b</Hash>
</Codenesium>*/