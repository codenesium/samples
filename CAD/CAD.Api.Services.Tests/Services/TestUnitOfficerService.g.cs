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
	[Trait("Table", "UnitOfficer")]
	[Trait("Area", "Services")]
	public partial class UnitOfficerServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IUnitOfficerRepository>();
			var records = new List<UnitOfficer>();
			records.Add(new UnitOfficer());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new UnitOfficerService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitOfficerModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			List<ApiUnitOfficerServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IUnitOfficerRepository>();
			var record = new UnitOfficer();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new UnitOfficerService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitOfficerModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			ApiUnitOfficerServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IUnitOfficerRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<UnitOfficer>(null));
			var service = new UnitOfficerService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitOfficerModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			ApiUnitOfficerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IUnitOfficerRepository>();
			var model = new ApiUnitOfficerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<UnitOfficer>())).Returns(Task.FromResult(new UnitOfficer()));
			var service = new UnitOfficerService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitOfficerModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			CreateResponse<ApiUnitOfficerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UnitOfficerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUnitOfficerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<UnitOfficer>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitOfficerCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IUnitOfficerRepository>();
			var model = new ApiUnitOfficerServerRequestModel();
			var validatorMock = new Mock<IApiUnitOfficerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUnitOfficerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UnitOfficerService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			CreateResponse<ApiUnitOfficerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUnitOfficerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitOfficerCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IUnitOfficerRepository>();
			var model = new ApiUnitOfficerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<UnitOfficer>())).Returns(Task.FromResult(new UnitOfficer()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new UnitOfficer()));
			var service = new UnitOfficerService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitOfficerModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			UpdateResponse<ApiUnitOfficerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UnitOfficerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<UnitOfficer>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitOfficerUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IUnitOfficerRepository>();
			var model = new ApiUnitOfficerServerRequestModel();
			var validatorMock = new Mock<IApiUnitOfficerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new UnitOfficer()));
			var service = new UnitOfficerService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			UpdateResponse<ApiUnitOfficerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitOfficerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitOfficerUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IUnitOfficerRepository>();
			var model = new ApiUnitOfficerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new UnitOfficerService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.UnitOfficerModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.UnitOfficerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitOfficerDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IUnitOfficerRepository>();
			var model = new ApiUnitOfficerServerRequestModel();
			var validatorMock = new Mock<IApiUnitOfficerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UnitOfficerService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitOfficerDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>c2da46d6cf899a48cd8c10520d8d1cdd</Hash>
</Codenesium>*/