using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "Services")]
	public partial class SpaceServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var records = new List<Space>();
			records.Add(new Space());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

			List<ApiSpaceResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var record = new Space();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

			ApiSpaceResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Space>(null));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

			ApiSpaceResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var model = new ApiSpaceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Space>())).Returns(Task.FromResult(new Space()));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Space>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var model = new ApiSpaceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Space>())).Returns(Task.FromResult(new Space()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Space()));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Space>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var model = new ApiSpaceRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceXSpaceFeatures_Exists()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			var records = new List<SpaceXSpaceFeature>();
			records.Add(new SpaceXSpaceFeature());
			mock.RepositoryMock.Setup(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

			List<ApiSpaceXSpaceFeatureResponseModel> response = await service.SpaceXSpaceFeatures(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SpaceXSpaceFeatures_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISpaceRepository>();
			mock.RepositoryMock.Setup(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SpaceXSpaceFeature>>(new List<SpaceXSpaceFeature>()));
			var service = new SpaceService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.SpaceModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLSpaceMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceMapperMock,
			                               mock.BOLMapperMockFactory.BOLSpaceXSpaceFeatureMapperMock,
			                               mock.DALMapperMockFactory.DALSpaceXSpaceFeatureMapperMock);

			List<ApiSpaceXSpaceFeatureResponseModel> response = await service.SpaceXSpaceFeatures(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SpaceXSpaceFeatures(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>83e575b9d801f5082fb1d2fb7dab6b19</Hash>
</Codenesium>*/