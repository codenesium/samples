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
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "Services")]
	public partial class PostHistoryTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeRepository>();
			var records = new List<PostHistoryType>();
			records.Add(new PostHistoryType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock);

			List<ApiPostHistoryTypeResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeRepository>();
			var record = new PostHistoryType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock);

			ApiPostHistoryTypeResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostHistoryType>(null));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock);

			ApiPostHistoryTypeResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeRepository>();
			var model = new ApiPostHistoryTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistoryType>())).Returns(Task.FromResult(new PostHistoryType()));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock);

			CreateResponse<ApiPostHistoryTypeResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostHistoryType>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeRepository>();
			var model = new ApiPostHistoryTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistoryType>())).Returns(Task.FromResult(new PostHistoryType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistoryType()));
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock);

			UpdateResponse<ApiPostHistoryTypeResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostHistoryType>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPostHistoryTypeRepository>();
			var model = new ApiPostHistoryTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostHistoryTypeService(mock.LoggerMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Object,
			                                         mock.BOLMapperMockFactory.BOLPostHistoryTypeMapperMock,
			                                         mock.DALMapperMockFactory.DALPostHistoryTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostHistoryTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>235ae6e8a4a63fc8a1bf8127fc1e8ffd</Hash>
</Codenesium>*/