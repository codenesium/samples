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
	[Trait("Table", "LinkStatus")]
	[Trait("Area", "Services")]
	public partial class LinkStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var records = new List<LinkStatus>();
			records.Add(new LinkStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkStatusServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var record = new LinkStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiLinkStatusServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkStatus>(null));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiLinkStatusServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var model = new ApiLinkStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkStatus>())).Returns(Task.FromResult(new LinkStatus()));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiLinkStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkStatusCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var model = new ApiLinkStatusServerRequestModel();
			var validatorMock = new Mock<IApiLinkStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiLinkStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiLinkStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkStatusCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var model = new ApiLinkStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkStatus>())).Returns(Task.FromResult(new LinkStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiLinkStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkStatusUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var model = new ApiLinkStatusServerRequestModel();
			var validatorMock = new Mock<IApiLinkStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkStatusServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiLinkStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkStatusUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var model = new ApiLinkStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkStatusDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var model = new ApiLinkStatusServerRequestModel();
			var validatorMock = new Mock<IApiLinkStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<LinkStatusDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var record = new LinkStatus();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiLinkStatusServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatus>(null));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiLinkStatusServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void LinksByLinkStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var records = new List<Link>();
			records.Add(new Link());
			mock.RepositoryMock.Setup(x => x.LinksByLinkStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkServerResponseModel> response = await service.LinksByLinkStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.LinksByLinkStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void LinksByLinkStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			mock.RepositoryMock.Setup(x => x.LinksByLinkStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Link>>(new List<Link>()));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkServerResponseModel> response = await service.LinksByLinkStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.LinksByLinkStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8d7a5da6db114bc6618d8627010fde36</Hash>
</Codenesium>*/