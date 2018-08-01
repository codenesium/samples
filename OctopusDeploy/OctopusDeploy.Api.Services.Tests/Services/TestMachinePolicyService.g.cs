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
	[Trait("Table", "MachinePolicy")]
	[Trait("Area", "Services")]
	public partial class MachinePolicyServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IMachinePolicyRepository>();
			var records = new List<MachinePolicy>();
			records.Add(new MachinePolicy());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MachinePolicyService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLMachinePolicyMapperMock,
			                                       mock.DALMapperMockFactory.DALMachinePolicyMapperMock);

			List<ApiMachinePolicyResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IMachinePolicyRepository>();
			var record = new MachinePolicy();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new MachinePolicyService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLMachinePolicyMapperMock,
			                                       mock.DALMapperMockFactory.DALMachinePolicyMapperMock);

			ApiMachinePolicyResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IMachinePolicyRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(null));
			var service = new MachinePolicyService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLMachinePolicyMapperMock,
			                                       mock.DALMapperMockFactory.DALMachinePolicyMapperMock);

			ApiMachinePolicyResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IMachinePolicyRepository>();
			var model = new ApiMachinePolicyRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<MachinePolicy>())).Returns(Task.FromResult(new MachinePolicy()));
			var service = new MachinePolicyService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLMachinePolicyMapperMock,
			                                       mock.DALMapperMockFactory.DALMachinePolicyMapperMock);

			CreateResponse<ApiMachinePolicyResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMachinePolicyRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<MachinePolicy>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IMachinePolicyRepository>();
			var model = new ApiMachinePolicyRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<MachinePolicy>())).Returns(Task.FromResult(new MachinePolicy()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new MachinePolicy()));
			var service = new MachinePolicyService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLMachinePolicyMapperMock,
			                                       mock.DALMapperMockFactory.DALMachinePolicyMapperMock);

			UpdateResponse<ApiMachinePolicyResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiMachinePolicyRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<MachinePolicy>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IMachinePolicyRepository>();
			var model = new ApiMachinePolicyRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new MachinePolicyService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLMachinePolicyMapperMock,
			                                       mock.DALMapperMockFactory.DALMachinePolicyMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IMachinePolicyRepository>();
			var record = new MachinePolicy();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new MachinePolicyService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLMachinePolicyMapperMock,
			                                       mock.DALMapperMockFactory.DALMachinePolicyMapperMock);

			ApiMachinePolicyResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMachinePolicyRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<MachinePolicy>(null));
			var service = new MachinePolicyService(mock.LoggerMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.MachinePolicyModelValidatorMock.Object,
			                                       mock.BOLMapperMockFactory.BOLMachinePolicyMapperMock,
			                                       mock.DALMapperMockFactory.DALMachinePolicyMapperMock);

			ApiMachinePolicyResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>5bc84baedb9b91ef7a6b9be15521eb5a</Hash>
</Codenesium>*/