using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "Services")]
	public partial class SpaceSpaceFeatureServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureService, ISpaceSpaceFeatureRepository>();
			var records = new List<SpaceSpaceFeature>();
			records.Add(new SpaceSpaceFeature());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureService, ISpaceSpaceFeatureRepository>();
			var record = new SpaceSpaceFeature();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ApiSpaceSpaceFeatureServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureService, ISpaceSpaceFeatureRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SpaceSpaceFeature>(null));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ApiSpaceSpaceFeatureServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureService, ISpaceSpaceFeatureRepository>();

			var model = new ApiSpaceSpaceFeatureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceSpaceFeature>())).Returns(Task.FromResult(new SpaceSpaceFeature()));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceSpaceFeatureServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SpaceSpaceFeature>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceSpaceFeatureCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureService, ISpaceSpaceFeatureRepository>();
			var model = new ApiSpaceSpaceFeatureServerRequestModel();
			var validatorMock = new Mock<IApiSpaceSpaceFeatureServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceSpaceFeatureServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceSpaceFeatureCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureService, ISpaceSpaceFeatureRepository>();
			var model = new ApiSpaceSpaceFeatureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceSpaceFeature>())).Returns(Task.FromResult(new SpaceSpaceFeature()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceSpaceFeature()));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SpaceSpaceFeature>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceSpaceFeatureUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureService, ISpaceSpaceFeatureRepository>();
			var model = new ApiSpaceSpaceFeatureServerRequestModel();
			var validatorMock = new Mock<IApiSpaceSpaceFeatureServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceSpaceFeature()));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceSpaceFeatureUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureService, ISpaceSpaceFeatureRepository>();
			var model = new ApiSpaceSpaceFeatureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceSpaceFeatureDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureService, ISpaceSpaceFeatureRepository>();
			var model = new ApiSpaceSpaceFeatureServerRequestModel();
			var validatorMock = new Mock<IApiSpaceSpaceFeatureServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceSpaceFeatureDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>921eacdb81fbe78da4d7744d85993f03</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/