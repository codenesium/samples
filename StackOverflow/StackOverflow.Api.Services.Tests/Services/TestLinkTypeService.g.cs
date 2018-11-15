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
	[Trait("Table", "LinkType")]
	[Trait("Area", "Services")]
	public partial class LinkTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var records = new List<LinkType>();
			records.Add(new LinkType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			List<ApiLinkTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var record = new LinkType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			ApiLinkTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<LinkType>(null));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			ApiLinkTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkType>())).Returns(Task.FromResult(new LinkType()));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			CreateResponse<ApiLinkTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiLinkTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<LinkType>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<LinkType>())).Returns(Task.FromResult(new LinkType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new LinkType()));
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			UpdateResponse<ApiLinkTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiLinkTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<LinkType>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ILinkTypeRepository>();
			var model = new ApiLinkTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new LinkTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLLinkTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALLinkTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.LinkTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>ede10f9ef37107c2fa0508c40eae210a</Hash>
</Codenesium>*/