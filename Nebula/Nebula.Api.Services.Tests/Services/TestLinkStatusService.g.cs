using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public async void Create()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var model = new ApiLinkStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkStatus>())).Returns(Task.FromResult(new LinkStatus()));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiLinkStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkStatus>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var model = new ApiLinkStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkStatus>())).Returns(Task.FromResult(new LinkStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatus()));
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiLinkStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkStatus>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var model = new ApiLinkStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkStatusService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLLinkStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkStatusMapperMock,
			                                    mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                    mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ILinkStatusRepository>();
			var record = new LinkStatus();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new LinkStatusService(mock.LoggerMock.Object,
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
    <Hash>104cf57e4f5e5a56c31fafe00e5ec9bb</Hash>
</Codenesium>*/