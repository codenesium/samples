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
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistory")]
	[Trait("Area", "Services")]
	public partial class PostHistoryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var records = new List<PostHistory>();
			records.Add(new PostHistory());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var record = new PostHistory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiPostHistoryServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostHistory>(null));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiPostHistoryServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var model = new ApiPostHistoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistory>())).Returns(Task.FromResult(new PostHistory()));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiPostHistoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostHistory>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var model = new ApiPostHistoryServerRequestModel();
			var validatorMock = new Mock<IApiPostHistoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiPostHistoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var model = new ApiPostHistoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistory>())).Returns(Task.FromResult(new PostHistory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiPostHistoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostHistory>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var model = new ApiPostHistoryServerRequestModel();
			var validatorMock = new Mock<IApiPostHistoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiPostHistoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var model = new ApiPostHistoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var model = new ApiPostHistoryServerRequestModel();
			var validatorMock = new Mock<IApiPostHistoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>7ab1c46b0f8ed4eb9e6c47e106a38ea5</Hash>
</Codenesium>*/