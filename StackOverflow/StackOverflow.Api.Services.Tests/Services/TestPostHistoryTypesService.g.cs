using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryTypes")]
	[Trait("Area", "Services")]
	public partial class PostHistoryTypesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			var records = new List<PostHistoryTypes>();
			records.Add(new PostHistoryTypes());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryTypesServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			var record = new PostHistoryTypes();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiPostHistoryTypesServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostHistoryTypes>(null));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiPostHistoryTypesServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			var model = new ApiPostHistoryTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistoryTypes>())).Returns(Task.FromResult(new PostHistoryTypes()));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiPostHistoryTypesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostHistoryTypes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypesCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			var model = new ApiPostHistoryTypesServerRequestModel();
			var validatorMock = new Mock<IApiPostHistoryTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiPostHistoryTypesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypesCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			var model = new ApiPostHistoryTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistoryTypes>())).Returns(Task.FromResult(new PostHistoryTypes()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryTypes()));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiPostHistoryTypesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostHistoryTypes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypesUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			var model = new ApiPostHistoryTypesServerRequestModel();
			var validatorMock = new Mock<IApiPostHistoryTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryTypes()));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiPostHistoryTypesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypesUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			var model = new ApiPostHistoryTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypesDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			var model = new ApiPostHistoryTypesServerRequestModel();
			var validatorMock = new Mock<IApiPostHistoryTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          validatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypesDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PostHistoryByPostHistoryTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			var records = new List<PostHistory>();
			records.Add(new PostHistory());
			mock.RepositoryMock.Setup(x => x.PostHistoryByPostHistoryTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoryByPostHistoryTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoryByPostHistoryTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoryByPostHistoryTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypesRepository>();
			mock.RepositoryMock.Setup(x => x.PostHistoryByPostHistoryTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostHistory>>(new List<PostHistory>()));
			var service = new PostHistoryTypesService(mock.LoggerMock.Object,
			                                          mock.MediatorMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.PostHistoryTypesModelValidatorMock.Object,
			                                          mock.DALMapperMockFactory.DALPostHistoryTypesMapperMock,
			                                          mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoryByPostHistoryTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoryByPostHistoryTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>2ec7372539ab567eba6dedb3dc0f9318</Hash>
</Codenesium>*/