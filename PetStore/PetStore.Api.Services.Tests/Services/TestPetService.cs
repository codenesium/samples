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
	[Trait("Table", "Pet")]
	[Trait("Area", "Services")]
	public partial class PetServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();
			var records = new List<Pet>();
			records.Add(new Pet());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiPetServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();
			var record = new Pet();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiPetServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Pet>(null));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiPetServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();

			var model = new ApiPetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pet>())).Returns(Task.FromResult(new Pet()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			CreateResponse<ApiPetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Pet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();
			var model = new ApiPetServerRequestModel();
			var validatorMock = new Mock<IApiPetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			CreateResponse<ApiPetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();
			var model = new ApiPetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pet>())).Returns(Task.FromResult(new Pet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			UpdateResponse<ApiPetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Pet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();
			var model = new ApiPetServerRequestModel();
			var validatorMock = new Mock<IApiPetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			UpdateResponse<ApiPetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();
			var model = new ApiPetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();
			var model = new ApiPetServerRequestModel();
			var validatorMock = new Mock<IApiPetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void SalesByPetId_Exists()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.SalesByPetId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleServerResponseModel> response = await service.SalesByPetId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesByPetId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesByPetId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPetService, IPetRepository>();
			mock.RepositoryMock.Setup(x => x.SalesByPetId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Sale>>(new List<Sale>()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock,
			                             mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleServerResponseModel> response = await service.SalesByPetId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesByPetId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c520ca07e55b99cd73b715ba83f2ba9f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/