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
	[Trait("Table", "PostLinks")]
	[Trait("Area", "Services")]
	public partial class PostLinksServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var records = new List<PostLinks>();
			records.Add(new PostLinks());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var record = new PostLinks();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ApiPostLinksServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostLinks>(null));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ApiPostLinksServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var model = new ApiPostLinksServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostLinks>())).Returns(Task.FromResult(new PostLinks()));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			CreateResponse<ApiPostLinksServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinksServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostLinks>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinksCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var model = new ApiPostLinksServerRequestModel();
			var validatorMock = new Mock<IApiPostLinksServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinksServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			CreateResponse<ApiPostLinksServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinksServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinksCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var model = new ApiPostLinksServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostLinks>())).Returns(Task.FromResult(new PostLinks()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostLinks()));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			UpdateResponse<ApiPostLinksServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinksServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostLinks>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinksUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var model = new ApiPostLinksServerRequestModel();
			var validatorMock = new Mock<IApiPostLinksServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinksServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostLinks()));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			UpdateResponse<ApiPostLinksServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinksServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinksUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var model = new ApiPostLinksServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinksDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var model = new ApiPostLinksServerRequestModel();
			var validatorMock = new Mock<IApiPostLinksServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinksDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByLinkTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var records = new List<PostLinks>();
			records.Add(new PostLinks());
			mock.RepositoryMock.Setup(x => x.ByLinkTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.ByLinkTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLinkTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLinkTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			mock.RepositoryMock.Setup(x => x.ByLinkTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLinks>>(new List<PostLinks>()));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.ByLinkTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLinkTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var records = new List<PostLinks>();
			records.Add(new PostLinks());
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLinks>>(new List<PostLinks>()));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByRelatedPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			var records = new List<PostLinks>();
			records.Add(new PostLinks());
			mock.RepositoryMock.Setup(x => x.ByRelatedPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.ByRelatedPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRelatedPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByRelatedPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinksRepository>();
			mock.RepositoryMock.Setup(x => x.ByRelatedPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLinks>>(new List<PostLinks>()));
			var service = new PostLinksService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostLinksModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.ByRelatedPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRelatedPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>db521d6fffbf1d58ed08402570f826d1</Hash>
</Codenesium>*/