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
	[Trait("Table", "Comments")]
	[Trait("Area", "Services")]
	public partial class CommentsServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var records = new List<Comments>();
			records.Add(new Comments());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			List<ApiCommentsServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var record = new Comments();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			ApiCommentsServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Comments>(null));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			ApiCommentsServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var model = new ApiCommentsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Comments>())).Returns(Task.FromResult(new Comments()));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			CreateResponse<ApiCommentsServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCommentsServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Comments>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentsCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var model = new ApiCommentsServerRequestModel();
			var validatorMock = new Mock<IApiCommentsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCommentsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			CreateResponse<ApiCommentsServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCommentsServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentsCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var model = new ApiCommentsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Comments>())).Returns(Task.FromResult(new Comments()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comments()));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			UpdateResponse<ApiCommentsServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentsServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Comments>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentsUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var model = new ApiCommentsServerRequestModel();
			var validatorMock = new Mock<IApiCommentsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentsServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comments()));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			UpdateResponse<ApiCommentsServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentsServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentsUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var model = new ApiCommentsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentsDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var model = new ApiCommentsServerRequestModel();
			var validatorMock = new Mock<IApiCommentsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CommentsDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByPostId_Exists()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var records = new List<Comments>();
			records.Add(new Comments());
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			List<ApiCommentsServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			mock.RepositoryMock.Setup(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Comments>>(new List<Comments>()));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			List<ApiCommentsServerResponseModel> response = await service.ByPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Exists()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var records = new List<Comments>();
			records.Add(new Comments());
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			List<ApiCommentsServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUserId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			mock.RepositoryMock.Setup(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Comments>>(new List<Comments>()));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.MediatorMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			List<ApiCommentsServerResponseModel> response = await service.ByUserId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUserId(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>f804f3adc6ccde642c7e6cb48f448c43</Hash>
</Codenesium>*/