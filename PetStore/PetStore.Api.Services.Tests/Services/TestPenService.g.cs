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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPenMapperMock);

			List<ApiPenServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var record = new Pen();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPenMapperMock);

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
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPenMapperMock);

			ApiPenServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var model = new ApiPenServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pen>())).Returns(Task.FromResult(new Pen()));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPenMapperMock);

			CreateResponse<ApiPenServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PenModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPenServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Pen>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PenCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var model = new ApiPenServerRequestModel();
			var validatorMock = new Mock<IApiPenServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPenServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.DALMapperMockFactory.DALPenMapperMock);

			CreateResponse<ApiPenServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPenServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PenCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var model = new ApiPenServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Pen>())).Returns(Task.FromResult(new Pen()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPenMapperMock);

			UpdateResponse<ApiPenServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PenModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPenServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Pen>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PenUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var model = new ApiPenServerRequestModel();
			var validatorMock = new Mock<IApiPenServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPenServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Pen()));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.DALMapperMockFactory.DALPenMapperMock);

			UpdateResponse<ApiPenServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPenServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PenUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var model = new ApiPenServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             mock.ModelValidatorMockFactory.PenModelValidatorMock.Object,
			                             mock.DALMapperMockFactory.DALPenMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PenModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PenDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPenRepository>();
			var model = new ApiPenServerRequestModel();
			var validatorMock = new Mock<IApiPenServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PenService(mock.LoggerMock.Object,
			                             mock.MediatorMock.Object,
			                             mock.RepositoryMock.Object,
			                             validatorMock.Object,
			                             mock.DALMapperMockFactory.DALPenMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PenDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>b2172134756ec2b3b226389b0e1fba64</Hash>
</Codenesium>*/