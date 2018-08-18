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
	[Trait("Table", "DeploymentProcess")]
	[Trait("Area", "Services")]
	public partial class DeploymentProcessServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IDeploymentProcessRepository>();
			var records = new List<DeploymentProcess>();
			records.Add(new DeploymentProcess());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DeploymentProcessService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.DeploymentProcessModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLDeploymentProcessMapperMock,
			                                           mock.DALMapperMockFactory.DALDeploymentProcessMapperMock);

			List<ApiDeploymentProcessResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDeploymentProcessRepository>();
			var record = new DeploymentProcess();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new DeploymentProcessService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.DeploymentProcessModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLDeploymentProcessMapperMock,
			                                           mock.DALMapperMockFactory.DALDeploymentProcessMapperMock);

			ApiDeploymentProcessResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDeploymentProcessRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<DeploymentProcess>(null));
			var service = new DeploymentProcessService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.DeploymentProcessModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLDeploymentProcessMapperMock,
			                                           mock.DALMapperMockFactory.DALDeploymentProcessMapperMock);

			ApiDeploymentProcessResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IDeploymentProcessRepository>();
			var model = new ApiDeploymentProcessRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeploymentProcess>())).Returns(Task.FromResult(new DeploymentProcess()));
			var service = new DeploymentProcessService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.DeploymentProcessModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLDeploymentProcessMapperMock,
			                                           mock.DALMapperMockFactory.DALDeploymentProcessMapperMock);

			CreateResponse<ApiDeploymentProcessResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DeploymentProcessModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentProcessRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DeploymentProcess>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IDeploymentProcessRepository>();
			var model = new ApiDeploymentProcessRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeploymentProcess>())).Returns(Task.FromResult(new DeploymentProcess()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DeploymentProcess()));
			var service = new DeploymentProcessService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.DeploymentProcessModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLDeploymentProcessMapperMock,
			                                           mock.DALMapperMockFactory.DALDeploymentProcessMapperMock);

			UpdateResponse<ApiDeploymentProcessResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DeploymentProcessModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDeploymentProcessRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DeploymentProcess>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IDeploymentProcessRepository>();
			var model = new ApiDeploymentProcessRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new DeploymentProcessService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.DeploymentProcessModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLDeploymentProcessMapperMock,
			                                           mock.DALMapperMockFactory.DALDeploymentProcessMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.DeploymentProcessModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>05d9097ff13cfc005a651a356ce0d9d3</Hash>
</Codenesium>*/