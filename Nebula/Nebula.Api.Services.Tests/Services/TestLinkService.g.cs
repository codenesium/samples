using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Link")]
	[Trait("Area", "Services")]
	public partial class LinkServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var records = new List<Link>();
			records.Add(new Link());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			List<ApiLinkServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var record = new Link();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ApiLinkServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Link>(null));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ApiLinkServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var model = new ApiLinkServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Link>())).Returns(Task.FromResult(new Link()));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			CreateResponse<ApiLinkServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Link>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var model = new ApiLinkServerRequestModel();
			var validatorMock = new Mock<IApiLinkServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			CreateResponse<ApiLinkServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var model = new ApiLinkServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Link>())).Returns(Task.FromResult(new Link()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Link()));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			UpdateResponse<ApiLinkServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Link>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var model = new ApiLinkServerRequestModel();
			var validatorMock = new Mock<IApiLinkServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Link()));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			UpdateResponse<ApiLinkServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var model = new ApiLinkServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var model = new ApiLinkServerRequestModel();
			var validatorMock = new Mock<IApiLinkServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByExternalId_Exists()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var record = new Link();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ApiLinkServerResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByExternalId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Link>(null));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			ApiLinkServerResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByChainId_Exists()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var records = new List<Link>();
			records.Add(new Link());
			mock.RepositoryMock.Setup(x => x.ByChainId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			List<ApiLinkServerResponseModel> response = await service.ByChainId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByChainId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByChainId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			mock.RepositoryMock.Setup(x => x.ByChainId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Link>>(new List<Link>()));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			List<ApiLinkServerResponseModel> response = await service.ByChainId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByChainId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LinkLogsByLinkId_Exists()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			var records = new List<LinkLog>();
			records.Add(new LinkLog());
			mock.RepositoryMock.Setup(x => x.LinkLogsByLinkId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			List<ApiLinkLogServerResponseModel> response = await service.LinkLogsByLinkId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.LinkLogsByLinkId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LinkLogsByLinkId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILinkRepository>();
			mock.RepositoryMock.Setup(x => x.LinkLogsByLinkId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<LinkLog>>(new List<LinkLog>()));
			var service = new LinkService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.LinkModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                              mock.DALMapperMockFactory.DALLinkMapperMock,
			                              mock.BOLMapperMockFactory.BOLLinkLogMapperMock,
			                              mock.DALMapperMockFactory.DALLinkLogMapperMock);

			List<ApiLinkLogServerResponseModel> response = await service.LinkLogsByLinkId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.LinkLogsByLinkId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>cdada3d73034327c2e31170f14321781</Hash>
</Codenesium>*/