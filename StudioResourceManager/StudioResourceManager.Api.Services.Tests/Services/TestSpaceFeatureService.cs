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
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "Services")]
	public partial class SpaceFeatureServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();
			var records = new List<SpaceFeature>();
			records.Add(new SpaceFeature());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			List<ApiSpaceFeatureServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();
			var record = new SpaceFeature();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ApiSpaceFeatureServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SpaceFeature>(null));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ApiSpaceFeatureServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();

			var model = new ApiSpaceFeatureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceFeature>())).Returns(Task.FromResult(new SpaceFeature()));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceFeatureServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SpaceFeature>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceFeatureCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			var validatorMock = new Mock<IApiSpaceFeatureServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceFeatureServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceFeatureCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceFeature>())).Returns(Task.FromResult(new SpaceFeature()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceFeatureServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SpaceFeature>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceFeatureUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			var validatorMock = new Mock<IApiSpaceFeatureServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceFeature()));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceFeatureServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceFeatureUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceFeatureDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();
			var model = new ApiSpaceFeatureServerRequestModel();
			var validatorMock = new Mock<IApiSpaceFeatureServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SpaceFeatureDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void SpaceSpaceFeaturesBySpaceFeatureId_Exists()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();
			var records = new List<SpaceSpaceFeature>();
			records.Add(new SpaceSpaceFeature());
			mock.RepositoryMock.Setup(x => x.SpaceSpaceFeaturesBySpaceFeatureId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await service.SpaceSpaceFeaturesBySpaceFeatureId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceSpaceFeaturesBySpaceFeatureId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceSpaceFeaturesBySpaceFeatureId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISpaceFeatureService, ISpaceFeatureRepository>();
			mock.RepositoryMock.Setup(x => x.SpaceSpaceFeaturesBySpaceFeatureId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceSpaceFeature>>(new List<SpaceSpaceFeature>()));
			var service = new SpaceFeatureService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.SpaceFeatureModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALSpaceFeatureMapperMock,
			                                      mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			List<ApiSpaceSpaceFeatureServerResponseModel> response = await service.SpaceSpaceFeaturesBySpaceFeatureId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceSpaceFeaturesBySpaceFeatureId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d1ae44de547bb72b6b7ca2b58a45835f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/