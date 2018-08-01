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
	[Trait("Table", "Pet")]
	[Trait("Area", "Services")]
	public partial class PetServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var records = new List<Pet>();
			records.Add(new Pet());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiPetResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var record = new Pet();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiPetResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Pet>(null));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiPetResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var model = new ApiPetRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pet>())).Returns(Task.FromResult(new Pet()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			CreateResponse<ApiPetResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPetRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Pet>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var model = new ApiPetRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pet>())).Returns(Task.FromResult(new Pet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			UpdateResponse<ApiPetResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Pet>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var model = new ApiPetRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Sales_Exists()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.Sales(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleResponseModel> response = await service.Sales(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Sales(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Sales_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			mock.RepositoryMock.Setup(x => x.Sales(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Sale>>(new List<Sale>()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.BOLMapperMockFactory.BOLPetMapperMock,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleResponseModel> response = await service.Sales(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Sales(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>55ed89eb2d73201c13314b3a95a9d734</Hash>
</Codenesium>*/