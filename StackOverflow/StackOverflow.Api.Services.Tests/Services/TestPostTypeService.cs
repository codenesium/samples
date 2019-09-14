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
	[Trait("Table", "PostType")]
	[Trait("Area", "Services")]
	public partial class PostTypeServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();
			var records = new List<PostType>();
			records.Add(new PostType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			List<ApiPostTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();
			var record = new PostType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			ApiPostTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostType>(null));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			ApiPostTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();

			var model = new ApiPostTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostType>())).Returns(Task.FromResult(new PostType()));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			CreateResponse<ApiPostTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypeCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();
			var model = new ApiPostTypeServerRequestModel();
			var validatorMock = new Mock<IApiPostTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			CreateResponse<ApiPostTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypeCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();
			var model = new ApiPostTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostType>())).Returns(Task.FromResult(new PostType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostType()));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			UpdateResponse<ApiPostTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypeUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();
			var model = new ApiPostTypeServerRequestModel();
			var validatorMock = new Mock<IApiPostTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostType()));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			UpdateResponse<ApiPostTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypeUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();
			var model = new ApiPostTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypeDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();
			var model = new ApiPostTypeServerRequestModel();
			var validatorMock = new Mock<IApiPostTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostTypeDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PostsByPostTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();
			var records = new List<Post>();
			records.Add(new Post());
			mock.RepositoryMock.Setup(x => x.PostsByPostTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			List<ApiPostServerResponseModel> response = await service.PostsByPostTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByPostTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostsByPostTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostTypeService, IPostTypeRepository>();
			mock.RepositoryMock.Setup(x => x.PostsByPostTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Post>>(new List<Post>()));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostMapperMock);

			List<ApiPostServerResponseModel> response = await service.PostsByPostTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostsByPostTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>63feacf8f96c8b3952b6764ecda0a089</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/