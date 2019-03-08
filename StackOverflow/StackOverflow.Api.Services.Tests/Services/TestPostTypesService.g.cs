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
	[Trait("Table", "PostTypes")]
	[Trait("Area", "Services")]
	public partial class PostTypesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var records = new List<PostTypes>();
			records.Add(new PostTypes());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			List<ApiPostTypesServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var record = new PostTypes();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			ApiPostTypesServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostTypes>(null));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			ApiPostTypesServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var model = new ApiPostTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostTypes>())).Returns(Task.FromResult(new PostTypes()));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			CreateResponse<ApiPostTypesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostTypes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypesCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var model = new ApiPostTypesServerRequestModel();
			var validatorMock = new Mock<IApiPostTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			CreateResponse<ApiPostTypesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypesCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var model = new ApiPostTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostTypes>())).Returns(Task.FromResult(new PostTypes()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			UpdateResponse<ApiPostTypesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostTypes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypesUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var model = new ApiPostTypesServerRequestModel();
			var validatorMock = new Mock<IApiPostTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypesServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			UpdateResponse<ApiPostTypesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypesUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var model = new ApiPostTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypesDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var model = new ApiPostTypesServerRequestModel();
			var validatorMock = new Mock<IApiPostTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypesDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PostsByPostTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var records = new List<Posts>();
			records.Add(new Posts());
			mock.RepositoryMock.Setup(x => x.PostsByPostTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			List<ApiPostsServerResponseModel> response = await service.PostsByPostTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByPostTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByPostTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			mock.RepositoryMock.Setup(x => x.PostsByPostTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Posts>>(new List<Posts>()));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostsMapperMock);

			List<ApiPostsServerResponseModel> response = await service.PostsByPostTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByPostTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c619668855c955632e56cc4fd6ecf83c</Hash>
</Codenesium>*/