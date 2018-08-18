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
	[Trait("Table", "PostHistory")]
	[Trait("Area", "Services")]
	public partial class PostHistoryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var records = new List<PostHistory>();
			records.Add(new PostHistory());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			List<ApiPostHistoryResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var record = new PostHistory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiPostHistoryResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostHistory>(null));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ApiPostHistoryResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var model = new ApiPostHistoryRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistory>())).Returns(Task.FromResult(new PostHistory()));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			CreateResponse<ApiPostHistoryResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostHistoryRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostHistory>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var model = new ApiPostHistoryRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostHistory>())).Returns(Task.FromResult(new PostHistory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			UpdateResponse<ApiPostHistoryResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostHistoryRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostHistory>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPostHistoryRepository>();
			var model = new ApiPostHistoryRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostHistoryService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLPostHistoryMapperMock,
			                                     mock.DALMapperMockFactory.DALPostHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>9cc25b44293018c19cc834a369373e1f</Hash>
</Codenesium>*/