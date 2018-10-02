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
	[Trait("Table", "LinkStatu")]
	[Trait("Area", "Services")]
	public partial class LinkStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			var records = new List<LinkStatu>();
			records.Add(new LinkStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkStatuResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			var record = new LinkStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiLinkStatuResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkStatu>(null));
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiLinkStatuResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			var model = new ApiLinkStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkStatu>())).Returns(Task.FromResult(new LinkStatu()));
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiLinkStatuResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkStatu>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			var model = new ApiLinkStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkStatu>())).Returns(Task.FromResult(new LinkStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkStatu()));
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiLinkStatuResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkStatu>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			var model = new ApiLinkStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			var record = new LinkStatu();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiLinkStatuResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<LinkStatu>(null));
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiLinkStatuResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void Links_Exists()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			var records = new List<Link>();
			records.Add(new Link());
			mock.RepositoryMock.Setup(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkResponseModel> response = await service.Links(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Links_Not_Exists()
		{
			var mock = new ServiceMockFacade<ILinkStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Link>>(new List<Link>()));
			var service = new LinkStatuService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkStatuModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkStatuMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkStatuMapperMock,
			                                   mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkResponseModel> response = await service.Links(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>f4da27c5b776279b989b3b78cc6ba187</Hash>
</Codenesium>*/