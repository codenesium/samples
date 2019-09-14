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
	[Trait("Table", "Studio")]
	[Trait("Area", "Services")]
	public partial class StudioServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IStudioService, IStudioRepository>();
			var records = new List<Studio>();
			records.Add(new Studio());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			List<ApiStudioServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IStudioService, IStudioRepository>();
			var record = new Studio();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			ApiStudioServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IStudioService, IStudioRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			ApiStudioServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IStudioService, IStudioRepository>();

			var model = new ApiStudioServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Studio>())).Returns(Task.FromResult(new Studio()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			CreateResponse<ApiStudioServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStudioServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Studio>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StudioCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IStudioService, IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			var validatorMock = new Mock<IApiStudioServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStudioServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			CreateResponse<ApiStudioServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStudioServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StudioCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IStudioService, IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Studio>())).Returns(Task.FromResult(new Studio()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			UpdateResponse<ApiStudioServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Studio>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StudioUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IStudioService, IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			var validatorMock = new Mock<IApiStudioServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Studio()));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			UpdateResponse<ApiStudioServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StudioUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IStudioService, IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.StudioModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.StudioModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StudioDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IStudioService, IStudioRepository>();
			var model = new ApiStudioServerRequestModel();
			var validatorMock = new Mock<IApiStudioServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new StudioService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALStudioMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<StudioDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>4acc25ce2cd2184dacb91bb2434fc6cc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/