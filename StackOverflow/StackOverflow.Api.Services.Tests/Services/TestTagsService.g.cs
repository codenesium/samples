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
	[Trait("Table", "Tags")]
	[Trait("Area", "Services")]
	public partial class TagsServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var records = new List<Tags>();
			records.Add(new Tags());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			List<ApiTagsServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var record = new Tags();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			ApiTagsServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Tags>(null));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			ApiTagsServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var model = new ApiTagsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tags>())).Returns(Task.FromResult(new Tags()));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			CreateResponse<ApiTagsServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TagsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTagsServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Tags>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TagsCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var model = new ApiTagsServerRequestModel();
			var validatorMock = new Mock<IApiTagsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTagsServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			CreateResponse<ApiTagsServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTagsServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TagsCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var model = new ApiTagsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tags>())).Returns(Task.FromResult(new Tags()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tags()));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			UpdateResponse<ApiTagsServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TagsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagsServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Tags>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TagsUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var model = new ApiTagsServerRequestModel();
			var validatorMock = new Mock<IApiTagsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagsServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tags()));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			UpdateResponse<ApiTagsServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTagsServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TagsUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var model = new ApiTagsServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TagsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TagsDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var model = new ApiTagsServerRequestModel();
			var validatorMock = new Mock<IApiTagsServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TagsDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByExcerptPostId_Exists()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var records = new List<Tags>();
			records.Add(new Tags());
			mock.RepositoryMock.Setup(x => x.ByExcerptPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			List<ApiTagsServerResponseModel> response = await service.ByExcerptPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByExcerptPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByExcerptPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			mock.RepositoryMock.Setup(x => x.ByExcerptPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tags>>(new List<Tags>()));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			List<ApiTagsServerResponseModel> response = await service.ByExcerptPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByExcerptPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByWikiPostId_Exists()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			var records = new List<Tags>();
			records.Add(new Tags());
			mock.RepositoryMock.Setup(x => x.ByWikiPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			List<ApiTagsServerResponseModel> response = await service.ByWikiPostId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByWikiPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByWikiPostId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITagsRepository>();
			mock.RepositoryMock.Setup(x => x.ByWikiPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Tags>>(new List<Tags>()));
			var service = new TagsService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.TagsModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALTagsMapperMock);

			List<ApiTagsServerResponseModel> response = await service.ByWikiPostId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByWikiPostId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>adb1eeded6b2ae5ea54e10ee02a98bbd</Hash>
</Codenesium>*/