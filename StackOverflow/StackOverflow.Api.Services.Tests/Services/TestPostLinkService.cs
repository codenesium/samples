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
	[Trait("Table", "PostLink")]
	[Trait("Area", "Services")]
	public partial class PostLinkServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var records = new List<PostLink>();
			records.Add(new PostLink());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var record = new PostLink();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ApiPostLinkServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostLink>(null));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ApiPostLinkServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();

			var model = new ApiPostLinkServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostLink>())).Returns(Task.FromResult(new PostLink()));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			CreateResponse<ApiPostLinkServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinkServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostLink>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinkCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var model = new ApiPostLinkServerRequestModel();
			var validatorMock = new Mock<IApiPostLinkServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinkServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			CreateResponse<ApiPostLinkServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostLinkServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinkCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var model = new ApiPostLinkServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostLink>())).Returns(Task.FromResult(new PostLink()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostLink()));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			UpdateResponse<ApiPostLinkServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinkServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostLink>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinkUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var model = new ApiPostLinkServerRequestModel();
			var validatorMock = new Mock<IApiPostLinkServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinkServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostLink()));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			UpdateResponse<ApiPostLinkServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostLinkServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinkUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var model = new ApiPostLinkServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinkDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var model = new ApiPostLinkServerRequestModel();
			var validatorMock = new Mock<IApiPostLinkServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostLinkDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByLinkTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var records = new List<PostLink>();
			records.Add(new PostLink());
			mock.RepositoryMock.Setup(x => x.ByLinkTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.ByLinkTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLinkTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLinkTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			mock.RepositoryMock.Setup(x => x.ByLinkTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLink>>(new List<PostLink>()));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.ByLinkTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLinkTypeId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var records = new List<PostLink>();
			records.Add(new PostLink());
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLink>>(new List<PostLink>()));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByRelatedPostId_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			var records = new List<PostLink>();
			records.Add(new PostLink());
			mock.RepositoryMock.Setup(x => x.ByRelatedPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.ByRelatedPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRelatedPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByRelatedPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostLinkService, IPostLinkRepository>();
			mock.RepositoryMock.Setup(x => x.ByRelatedPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLink>>(new List<PostLink>()));
			var service = new PostLinkService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostLinkModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostLinkMapperMock);

			List<ApiPostLinkServerResponseModel> response = await service.ByRelatedPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByRelatedPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8d3c99c0025d82e3ff3ad8fb5220d666</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/