using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "Services")]
	public partial class SpaceSpaceFeatureServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureRepository>();
			var records = new List<SpaceSpaceFeature>();
			records.Add(new SpaceSpaceFeature());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			List<ApiSpaceSpaceFeatureResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureRepository>();
			var record = new SpaceSpaceFeature();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ApiSpaceSpaceFeatureResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SpaceSpaceFeature>(null));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ApiSpaceSpaceFeatureResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureRepository>();
			var model = new ApiSpaceSpaceFeatureRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceSpaceFeature>())).Returns(Task.FromResult(new SpaceSpaceFeature()));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			CreateResponse<ApiSpaceSpaceFeatureResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceSpaceFeatureRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SpaceSpaceFeature>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureRepository>();
			var model = new ApiSpaceSpaceFeatureRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SpaceSpaceFeature>())).Returns(Task.FromResult(new SpaceSpaceFeature()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SpaceSpaceFeature()));
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			UpdateResponse<ApiSpaceSpaceFeatureResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceSpaceFeatureRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SpaceSpaceFeature>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISpaceSpaceFeatureRepository>();
			var model = new ApiSpaceSpaceFeatureRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SpaceSpaceFeatureService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLSpaceSpaceFeatureMapperMock,
			                                           mock.DALMapperMockFactory.DALSpaceSpaceFeatureMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SpaceSpaceFeatureModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b36ef64b01cc5913eb5c9faafd554160</Hash>
</Codenesium>*/