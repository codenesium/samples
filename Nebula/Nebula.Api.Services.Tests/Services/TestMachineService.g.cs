using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Machine")]
	[Trait("Area", "Services")]
	public partial class MachineServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			var records = new List<Machine>();
			records.Add(new Machine());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiMachineResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			var record = new Machine();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiMachineResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Machine>(null));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiMachineResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			var model = new ApiMachineRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Machine>())).Returns(Task.FromResult(new Machine()));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			CreateResponse<ApiMachineResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.MachineModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Machine>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			var model = new ApiMachineRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Machine>())).Returns(Task.FromResult(new Machine()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Machine()));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			UpdateResponse<ApiMachineResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.MachineModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Machine>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			var model = new ApiMachineRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.MachineModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByMachineGuid_Exists()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			var record = new Machine();
			mock.RepositoryMock.Setup(x => x.ByMachineGuid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiMachineResponseModel response = await service.ByMachineGuid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByMachineGuid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByMachineGuid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			mock.RepositoryMock.Setup(x => x.ByMachineGuid(It.IsAny<Guid>())).Returns(Task.FromResult<Machine>(null));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			ApiMachineResponseModel response = await service.ByMachineGuid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByMachineGuid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void Links_Exists()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			var records = new List<Link>();
			records.Add(new Link());
			mock.RepositoryMock.Setup(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkResponseModel> response = await service.Links(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Links_Not_Exists()
		{
			var mock = new ServiceMockFacade<IMachineRepository>();
			mock.RepositoryMock.Setup(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Link>>(new List<Link>()));
			var service = new MachineService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLMachineMapperMock,
			                                 mock.DALMapperMockFactory.DALMachineMapperMock,
			                                 mock.BOLMapperMockFactory.BOLLinkMapperMock,
			                                 mock.DALMapperMockFactory.DALLinkMapperMock);

			List<ApiLinkResponseModel> response = await service.Links(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Links(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>eed2b09e89cc2f04aab463dde1d9886b</Hash>
</Codenesium>*/