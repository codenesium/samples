using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "Services")]
	public partial class ChainStatusServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			var records = new List<ChainStatus>();
			records.Add(new ChainStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			List<ApiChainStatusServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			var record = new ChainStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			ApiChainStatusServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ChainStatus>(null));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			ApiChainStatusServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();

			var model = new ApiChainStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ChainStatus>())).Returns(Task.FromResult(new ChainStatus()));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			CreateResponse<ApiChainStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiChainStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ChainStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ChainStatusCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			var model = new ApiChainStatusServerRequestModel();
			var validatorMock = new Mock<IApiChainStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiChainStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			CreateResponse<ApiChainStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiChainStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ChainStatusCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			var model = new ApiChainStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ChainStatus>())).Returns(Task.FromResult(new ChainStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			UpdateResponse<ApiChainStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ChainStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ChainStatusUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			var model = new ApiChainStatusServerRequestModel();
			var validatorMock = new Mock<IApiChainStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainStatusServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			UpdateResponse<ApiChainStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiChainStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ChainStatusUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			var model = new ApiChainStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ChainStatusDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			var model = new ApiChainStatusServerRequestModel();
			var validatorMock = new Mock<IApiChainStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ChainStatusDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			var record = new ChainStatus();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			ApiChainStatusServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatus>(null));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			ApiChainStatusServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ChainsByChainStatusId_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			var records = new List<Chain>();
			records.Add(new Chain());
			mock.RepositoryMock.Setup(x => x.ChainsByChainStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			List<ApiChainServerResponseModel> response = await service.ChainsByChainStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ChainsByChainStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ChainsByChainStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IChainStatusService, IChainStatusRepository>();
			mock.RepositoryMock.Setup(x => x.ChainsByChainStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Chain>>(new List<Chain>()));
			var service = new ChainStatusService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ChainStatusModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALChainStatusMapperMock,
			                                     mock.DALMapperMockFactory.DALChainMapperMock);

			List<ApiChainServerResponseModel> response = await service.ChainsByChainStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ChainsByChainStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>61804eb6acea69e0b4acb44141163fe6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/