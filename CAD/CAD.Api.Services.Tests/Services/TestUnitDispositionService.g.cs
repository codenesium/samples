using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitDisposition")]
	[Trait("Area", "Services")]
	public partial class UnitDispositionServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IUnitDispositionRepository>();
			var records = new List<UnitDisposition>();
			records.Add(new UnitDisposition());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new UnitDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.UnitDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALUnitDispositionMapperMock);

			List<ApiUnitDispositionServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IUnitDispositionRepository>();
			var record = new UnitDisposition();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new UnitDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.UnitDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALUnitDispositionMapperMock);

			ApiUnitDispositionServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IUnitDispositionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<UnitDisposition>(null));
			var service = new UnitDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.UnitDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALUnitDispositionMapperMock);

			ApiUnitDispositionServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IUnitDispositionRepository>();
			var model = new ApiUnitDispositionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<UnitDisposition>())).Returns(Task.FromResult(new UnitDisposition()));
			var service = new UnitDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.UnitDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALUnitDispositionMapperMock);

			CreateResponse<ApiUnitDispositionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UnitDispositionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUnitDispositionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<UnitDisposition>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitDispositionCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IUnitDispositionRepository>();
			var model = new ApiUnitDispositionServerRequestModel();
			var validatorMock = new Mock<IApiUnitDispositionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UnitDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALUnitDispositionMapperMock);

			CreateResponse<ApiUnitDispositionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUnitDispositionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitDispositionCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IUnitDispositionRepository>();
			var model = new ApiUnitDispositionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<UnitDisposition>())).Returns(Task.FromResult(new UnitDisposition()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new UnitDisposition()));
			var service = new UnitDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.UnitDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALUnitDispositionMapperMock);

			UpdateResponse<ApiUnitDispositionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UnitDispositionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<UnitDisposition>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitDispositionUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IUnitDispositionRepository>();
			var model = new ApiUnitDispositionServerRequestModel();
			var validatorMock = new Mock<IApiUnitDispositionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new UnitDisposition()));
			var service = new UnitDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALUnitDispositionMapperMock);

			UpdateResponse<ApiUnitDispositionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitDispositionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitDispositionUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IUnitDispositionRepository>();
			var model = new ApiUnitDispositionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new UnitDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.UnitDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALUnitDispositionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.UnitDispositionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitDispositionDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IUnitDispositionRepository>();
			var model = new ApiUnitDispositionServerRequestModel();
			var validatorMock = new Mock<IApiUnitDispositionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UnitDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALUnitDispositionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitDispositionDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>94f7d085df4c5c5c43cf16f30bc8823c</Hash>
</Codenesium>*/