using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "Services")]
	public partial class OtherTransportServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IOtherTransportService, IOtherTransportRepository>();
			var records = new List<OtherTransport>();
			records.Add(new OtherTransport());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiOtherTransportServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IOtherTransportService, IOtherTransportRepository>();
			var record = new OtherTransport();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiOtherTransportServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IOtherTransportService, IOtherTransportRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<OtherTransport>(null));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiOtherTransportServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IOtherTransportService, IOtherTransportRepository>();

			var model = new ApiOtherTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OtherTransport>())).Returns(Task.FromResult(new OtherTransport()));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			CreateResponse<ApiOtherTransportServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOtherTransportServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<OtherTransport>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OtherTransportCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IOtherTransportService, IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			var validatorMock = new Mock<IApiOtherTransportServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			CreateResponse<ApiOtherTransportServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOtherTransportServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OtherTransportCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IOtherTransportService, IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OtherTransport>())).Returns(Task.FromResult(new OtherTransport()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OtherTransport()));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			UpdateResponse<ApiOtherTransportServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<OtherTransport>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OtherTransportUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IOtherTransportService, IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			var validatorMock = new Mock<IApiOtherTransportServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OtherTransport()));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			UpdateResponse<ApiOtherTransportServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOtherTransportServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OtherTransportUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IOtherTransportService, IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OtherTransportDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IOtherTransportService, IOtherTransportRepository>();
			var model = new ApiOtherTransportServerRequestModel();
			var validatorMock = new Mock<IApiOtherTransportServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<OtherTransportDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>37fae9b2ff6f773765c14e54c4267111</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/