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
	[Trait("Table", "PostTypes")]
	[Trait("Area", "Services")]
	public partial class PostTypesServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var records = new List<PostTypes>();
			records.Add(new PostTypes());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock);

			List<ApiPostTypesResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var record = new PostTypes();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock);

			ApiPostTypesResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PostTypes>(null));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock);

			ApiPostTypesResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var model = new ApiPostTypesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostTypes>())).Returns(Task.FromResult(new PostTypes()));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock);

			CreateResponse<ApiPostTypesResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPostTypesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PostTypes>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var model = new ApiPostTypesRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PostTypes>())).Returns(Task.FromResult(new PostTypes()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostTypes()));
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock);

			UpdateResponse<ApiPostTypesResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPostTypesRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PostTypes>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IPostTypesRepository>();
			var model = new ApiPostTypesRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PostTypesService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLPostTypesMapperMock,
			                                   mock.DALMapperMockFactory.DALPostTypesMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PostTypesModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>414aeeb5f1f52125528fa43dc560ceb3</Hash>
</Codenesium>*/