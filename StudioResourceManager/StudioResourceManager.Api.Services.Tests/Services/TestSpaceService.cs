using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "Services")]
	public partial class SpaceServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();
			var records = new List<Space>();
			records.Add(new Space());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			List<ApiSpaceServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();
			var record = new Space();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ApiSpaceServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Space>(null));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ApiSpaceServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();

			var model = new ApiSpaceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Space>())).Returns(Task.FromResult(new Space()));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Space>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();
			var model = new ApiSpaceServerRequestModel();
			var validatorMock = new Mock<IApiSpaceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();
			var model = new ApiSpaceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Space>())).Returns(Task.FromResult(new Space()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Space>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();
			var model = new ApiSpaceServerRequestModel();
			var validatorMock = new Mock<IApiSpaceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();
			var model = new ApiSpaceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();
			var model = new ApiSpaceServerRequestModel();
			var validatorMock = new Mock<IApiSpaceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void SpaceSpaceFeaturesBySpaceId_Exists()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();
			var records = new List<SpaceSpaceFeature>();
			records.Add(new SpaceSpaceFeature());
			mock.RepositoryMock.Setup(x => x.SpaceSpaceFeaturesBySpaceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await service.SpaceSpaceFeaturesBySpaceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceSpaceFeaturesBySpaceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceSpaceFeaturesBySpaceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISpaceService, ISpaceRepository>();
			mock.RepositoryMock.Setup(x => x.SpaceSpaceFeaturesBySpaceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceSpaceFeature>>(new List<SpaceSpaceFeature>()));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await service.SpaceSpaceFeaturesBySpaceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceSpaceFeaturesBySpaceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6ba7f1a9d6cb3b23affe6d0ab54e6f6e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/