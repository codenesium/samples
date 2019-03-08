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
		public async void All()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var records = new List<Pet>();
			records.Add(new Pet());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			List<ApiPetServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var record = new Pet();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			ApiPetServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Pet>(null));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			ApiPetServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var model = new ApiPetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pet>())).Returns(Task.FromResult(new Pet()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			CreateResponse<ApiPetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PetModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Pet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var model = new ApiPetServerRequestModel();
			var validatorMock = new Mock<IApiPetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPetServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			CreateResponse<ApiPetServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var model = new ApiPetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pet>())).Returns(Task.FromResult(new Pet()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			UpdateResponse<ApiPetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PetModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Pet>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var model = new ApiPetServerRequestModel();
			var validatorMock = new Mock<IApiPetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pet()));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			UpdateResponse<ApiPetServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPetServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var model = new ApiPetServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PetModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PetModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPetRepository>();
			var model = new ApiPetServerRequestModel();
			var validatorMock = new Mock<IApiPetServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PetService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.DALMapperMockFactory.DALPetMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PetDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>fc5817a45e299717d1553de7508b691a</Hash>
</Codenesium>*/