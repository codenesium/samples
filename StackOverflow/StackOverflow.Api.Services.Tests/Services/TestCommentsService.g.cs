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
	[Trait("Table", "Comments")]
	[Trait("Area", "Services")]
	public partial class CommentsServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var records = new List<Comments>();
			records.Add(new Comments());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCommentsMapperMock,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			List<ApiCommentsResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var record = new Comments();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCommentsMapperMock,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			ApiCommentsResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Comments>(null));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCommentsMapperMock,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			ApiCommentsResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var model = new ApiCommentsRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Comments>())).Returns(Task.FromResult(new Comments()));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCommentsMapperMock,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			CreateResponse<ApiCommentsResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCommentsRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Comments>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var model = new ApiCommentsRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Comments>())).Returns(Task.FromResult(new Comments()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comments()));
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCommentsMapperMock,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			UpdateResponse<ApiCommentsResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentsRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Comments>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ICommentsRepository>();
			var model = new ApiCommentsRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CommentsService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLCommentsMapperMock,
			                                  mock.DALMapperMockFactory.DALCommentsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CommentsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>e1ae609a2b9e000ffc2f040b9170fa22</Hash>
</Codenesium>*/