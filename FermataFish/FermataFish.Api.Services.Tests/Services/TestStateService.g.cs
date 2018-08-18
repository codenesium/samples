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
	[Trait("Table", "State")]
	[Trait("Area", "Services")]
	public partial class StateServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IStateRepository>();
			var records = new List<State>();
			records.Add(new State());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StateService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.StateModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLStateMapperMock,
			                               mock.DALMapperMockFactory.DALStateMapperMock,
			                               mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                               mock.DALMapperMockFactory.DALStudioMapperMock);

			List<ApiStateResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IStateRepository>();
			var record = new State();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new StateService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.StateModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLStateMapperMock,
			                               mock.DALMapperMockFactory.DALStateMapperMock,
			                               mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                               mock.DALMapperMockFactory.DALStudioMapperMock);

			ApiStateResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IStateRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<State>(null));
			var service = new StateService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.StateModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLStateMapperMock,
			                               mock.DALMapperMockFactory.DALStateMapperMock,
			                               mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                               mock.DALMapperMockFactory.DALStudioMapperMock);

			ApiStateResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IStateRepository>();
			var model = new ApiStateRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<State>())).Returns(Task.FromResult(new State()));
			var service = new StateService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.StateModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLStateMapperMock,
			                               mock.DALMapperMockFactory.DALStateMapperMock,
			                               mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                               mock.DALMapperMockFactory.DALStudioMapperMock);

			CreateResponse<ApiStateResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.StateModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStateRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<State>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IStateRepository>();
			var model = new ApiStateRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<State>())).Returns(Task.FromResult(new State()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new State()));
			var service = new StateService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.StateModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLStateMapperMock,
			                               mock.DALMapperMockFactory.DALStateMapperMock,
			                               mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                               mock.DALMapperMockFactory.DALStudioMapperMock);

			UpdateResponse<ApiStateResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.StateModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStateRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<State>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IStateRepository>();
			var model = new ApiStateRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new StateService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.StateModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLStateMapperMock,
			                               mock.DALMapperMockFactory.DALStateMapperMock,
			                               mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                               mock.DALMapperMockFactory.DALStudioMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.StateModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Studios_Exists()
		{
			var mock = new ServiceMockFacade<IStateRepository>();
			var records = new List<Studio>();
			records.Add(new Studio());
			mock.RepositoryMock.Setup(x => x.Studios(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StateService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.StateModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLStateMapperMock,
			                               mock.DALMapperMockFactory.DALStateMapperMock,
			                               mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                               mock.DALMapperMockFactory.DALStudioMapperMock);

			List<ApiStudioResponseModel> response = await service.Studios(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Studios(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Studios_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStateRepository>();
			mock.RepositoryMock.Setup(x => x.Studios(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Studio>>(new List<Studio>()));
			var service = new StateService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.StateModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLStateMapperMock,
			                               mock.DALMapperMockFactory.DALStateMapperMock,
			                               mock.BOLMapperMockFactory.BOLStudioMapperMock,
			                               mock.DALMapperMockFactory.DALStudioMapperMock);

			List<ApiStudioResponseModel> response = await service.Studios(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Studios(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>419133a02c7ee4039c583f7f288a9f61</Hash>
</Codenesium>*/