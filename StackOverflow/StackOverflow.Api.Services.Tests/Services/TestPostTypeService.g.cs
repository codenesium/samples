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
	[Trait("Table", "PostType")]
	[Trait("Area", "Services")]
	public partial class PostTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostTypeRepository>();
			var records = new List<PostType>();
			records.Add(new PostType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock);

			List<ApiPostTypeResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostTypeRepository>();
			var record = new PostType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock);

			ApiPostTypeResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostType>(null));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock);

			ApiPostTypeResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPostTypeRepository>();
			var model = new ApiPostTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostType>())).Returns(Task.FromResult(new PostType()));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock);

			CreateResponse<ApiPostTypeResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostType>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPostTypeRepository>();
			var model = new ApiPostTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostType>())).Returns(Task.FromResult(new PostType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostType()));
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock);

			UpdateResponse<ApiPostTypeResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypeRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostType>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPostTypeRepository>();
			var model = new ApiPostTypeRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLPostTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALPostTypeMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>34e9dd84c921fb404fc28a6320e952bd</Hash>
</Codenesium>*/