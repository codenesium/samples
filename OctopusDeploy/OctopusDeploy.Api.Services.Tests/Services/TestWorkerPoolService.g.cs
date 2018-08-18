using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "WorkerPool")]
	[Trait("Area", "Services")]
	public partial class WorkerPoolServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IWorkerPoolRepository>();
			var records = new List<WorkerPool>();
			records.Add(new WorkerPool());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new WorkerPoolService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLWorkerPoolMapperMock,
			                                    mock.DALMapperMockFactory.DALWorkerPoolMapperMock);

			List<ApiWorkerPoolResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IWorkerPoolRepository>();
			var record = new WorkerPool();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new WorkerPoolService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLWorkerPoolMapperMock,
			                                    mock.DALMapperMockFactory.DALWorkerPoolMapperMock);

			ApiWorkerPoolResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IWorkerPoolRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<WorkerPool>(null));
			var service = new WorkerPoolService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLWorkerPoolMapperMock,
			                                    mock.DALMapperMockFactory.DALWorkerPoolMapperMock);

			ApiWorkerPoolResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IWorkerPoolRepository>();
			var model = new ApiWorkerPoolRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkerPool>())).Returns(Task.FromResult(new WorkerPool()));
			var service = new WorkerPoolService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLWorkerPoolMapperMock,
			                                    mock.DALMapperMockFactory.DALWorkerPoolMapperMock);

			CreateResponse<ApiWorkerPoolResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiWorkerPoolRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<WorkerPool>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IWorkerPoolRepository>();
			var model = new ApiWorkerPoolRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkerPool>())).Returns(Task.FromResult(new WorkerPool()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerPool()));
			var service = new WorkerPoolService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLWorkerPoolMapperMock,
			                                    mock.DALMapperMockFactory.DALWorkerPoolMapperMock);

			UpdateResponse<ApiWorkerPoolResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiWorkerPoolRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<WorkerPool>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IWorkerPoolRepository>();
			var model = new ApiWorkerPoolRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new WorkerPoolService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLWorkerPoolMapperMock,
			                                    mock.DALMapperMockFactory.DALWorkerPoolMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IWorkerPoolRepository>();
			var record = new WorkerPool();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new WorkerPoolService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLWorkerPoolMapperMock,
			                                    mock.DALMapperMockFactory.DALWorkerPoolMapperMock);

			ApiWorkerPoolResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IWorkerPoolRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<WorkerPool>(null));
			var service = new WorkerPoolService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.WorkerPoolModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLWorkerPoolMapperMock,
			                                    mock.DALMapperMockFactory.DALWorkerPoolMapperMock);

			ApiWorkerPoolResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>88ae63c044c86895ce4ad8864dfdd7cb</Hash>
</Codenesium>*/