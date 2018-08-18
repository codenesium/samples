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
	[Trait("Table", "DeploymentRelatedMachine")]
	[Trait("Area", "Services")]
	public partial class DeploymentRelatedMachineServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			var records = new List<DeploymentRelatedMachine>();
			records.Add(new DeploymentRelatedMachine());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			List<ApiDeploymentRelatedMachineResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			var record = new DeploymentRelatedMachine();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			ApiDeploymentRelatedMachineResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<DeploymentRelatedMachine>(null));
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			ApiDeploymentRelatedMachineResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			var model = new ApiDeploymentRelatedMachineRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeploymentRelatedMachine>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			CreateResponse<ApiDeploymentRelatedMachineResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentRelatedMachineRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DeploymentRelatedMachine>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			var model = new ApiDeploymentRelatedMachineRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeploymentRelatedMachine>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeploymentRelatedMachine()));
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			UpdateResponse<ApiDeploymentRelatedMachineResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeploymentRelatedMachineRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DeploymentRelatedMachine>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			var model = new ApiDeploymentRelatedMachineRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByDeploymentId_Exists()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			var records = new List<DeploymentRelatedMachine>();
			records.Add(new DeploymentRelatedMachine());
			mock.RepositoryMock.Setup(x => x.ByDeploymentId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			List<ApiDeploymentRelatedMachineResponseModel> response = await service.ByDeploymentId(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDeploymentId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByDeploymentId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			mock.RepositoryMock.Setup(x => x.ByDeploymentId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<DeploymentRelatedMachine>>(new List<DeploymentRelatedMachine>()));
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			List<ApiDeploymentRelatedMachineResponseModel> response = await service.ByDeploymentId(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDeploymentId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByMachineId_Exists()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			var records = new List<DeploymentRelatedMachine>();
			records.Add(new DeploymentRelatedMachine());
			mock.RepositoryMock.Setup(x => x.ByMachineId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			List<ApiDeploymentRelatedMachineResponseModel> response = await service.ByMachineId(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByMachineId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByMachineId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDeploymentRelatedMachineRepository>();
			mock.RepositoryMock.Setup(x => x.ByMachineId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<DeploymentRelatedMachine>>(new List<DeploymentRelatedMachine>()));
			var service = new DeploymentRelatedMachineService(mock.LoggerMock.Object,
			                                                  mock.RepositoryMock.Object,
			                                                  mock.ModelValidatorMockFactory.DeploymentRelatedMachineModelValidatorMock.Object,
			                                                  mock.BOLMapperMockFactory.BOLDeploymentRelatedMachineMapperMock,
			                                                  mock.DALMapperMockFactory.DALDeploymentRelatedMachineMapperMock);

			List<ApiDeploymentRelatedMachineResponseModel> response = await service.ByMachineId(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByMachineId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5300d50dfed2d269cd927a95be3826d1</Hash>
</Codenesium>*/