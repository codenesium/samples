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
	[Trait("Table", "LinkTypes")]
	[Trait("Area", "Services")]
	public partial class LinkTypesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var records = new List<LinkTypes>();
			records.Add(new LinkTypes());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiLinkTypesServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var record = new LinkTypes();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ApiLinkTypesServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkTypes>(null));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ApiLinkTypesServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var model = new ApiLinkTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkTypes>())).Returns(Task.FromResult(new LinkTypes()));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			CreateResponse<ApiLinkTypesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkTypes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypesCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var model = new ApiLinkTypesServerRequestModel();
			var validatorMock = new Mock<IApiLinkTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypesServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			CreateResponse<ApiLinkTypesServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypesCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var model = new ApiLinkTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkTypes>())).Returns(Task.FromResult(new LinkTypes()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkTypes()));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			UpdateResponse<ApiLinkTypesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypesServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkTypes>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypesUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var model = new ApiLinkTypesServerRequestModel();
			var validatorMock = new Mock<IApiLinkTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypesServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkTypes()));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			UpdateResponse<ApiLinkTypesServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypesServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypesUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var model = new ApiLinkTypesServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypesDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var model = new ApiLinkTypesServerRequestModel();
			var validatorMock = new Mock<IApiLinkTypesServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   validatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkTypesDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PostLinksByLinkTypeId_Exists()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var records = new List<PostLinks>();
			records.Add(new PostLinks());
			mock.RepositoryMock.Setup(x => x.PostLinksByLinkTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.PostLinksByLinkTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByLinkTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PostLinksByLinkTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			mock.RepositoryMock.Setup(x => x.PostLinksByLinkTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PostLinks>>(new List<PostLinks>()));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.MediatorMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostLinksMapperMock);

			List<ApiPostLinksServerResponseModel> response = await service.PostLinksByLinkTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PostLinksByLinkTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>3865f10419a6e9d5efbfab6606eeae59</Hash>
</Codenesium>*/