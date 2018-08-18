using FluentAssertions;
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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock);

			List<ApiLinkTypesResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var record = new LinkTypes();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock);

			ApiLinkTypesResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkTypes>(null));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock);

			ApiLinkTypesResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var model = new ApiLinkTypesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkTypes>())).Returns(Task.FromResult(new LinkTypes()));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock);

			CreateResponse<ApiLinkTypesResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkTypes>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var model = new ApiLinkTypesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkTypes>())).Returns(Task.FromResult(new LinkTypes()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkTypes()));
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock);

			UpdateResponse<ApiLinkTypesResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkTypes>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ILinkTypesRepository>();
			var model = new ApiLinkTypesRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLLinkTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALLinkTypesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkTypesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b468a1b0ae568c182c47b1702e64ebd6</Hash>
</Codenesium>*/