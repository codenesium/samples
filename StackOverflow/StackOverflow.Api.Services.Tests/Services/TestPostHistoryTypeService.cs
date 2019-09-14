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
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "Services")]
	public partial class PostHistoryTypeServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();
			var records = new List<PostHistoryType>();
			records.Add(new PostHistoryType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();
			var record = new PostHistoryType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiPostHistoryTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostHistoryType>(null));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiPostHistoryTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();

			var model = new ApiPostHistoryTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistoryType>())).Returns(Task.FromResult(new PostHistoryType()));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiPostHistoryTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostHistoryType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypeCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();
			var model = new ApiPostHistoryTypeServerRequestModel();
			var validatorMock = new Mock<IApiPostHistoryTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiPostHistoryTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypeCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();
			var model = new ApiPostHistoryTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistoryType>())).Returns(Task.FromResult(new PostHistoryType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiPostHistoryTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostHistoryType>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypeUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();
			var model = new ApiPostHistoryTypeServerRequestModel();
			var validatorMock = new Mock<IApiPostHistoryTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiPostHistoryTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypeUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();
			var model = new ApiPostHistoryTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypeDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();
			var model = new ApiPostHistoryTypeServerRequestModel();
			var validatorMock = new Mock<IApiPostHistoryTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PostHistoryTypeDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PostHistoriesByPostHistoryTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();
			var records = new List<PostHistory>();
			records.Add(new PostHistory());
			mock.RepositoryMock.Setup(x => x.PostHistoriesByPostHistoryTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoriesByPostHistoryTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoriesByPostHistoryTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostHistoriesByPostHistoryTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeService, IPostHistoryTypeRepository>();
			mock.RepositoryMock.Setup(x => x.PostHistoriesByPostHistoryTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostHistory>>(new List<PostHistory>()));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryServerResponseModel> response = await service.PostHistoriesByPostHistoryTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostHistoriesByPostHistoryTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>007dd9afe739462c28fc41615968abd4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/