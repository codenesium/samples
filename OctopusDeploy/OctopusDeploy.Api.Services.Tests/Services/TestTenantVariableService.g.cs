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
	[Trait("Table", "TenantVariable")]
	[Trait("Area", "Services")]
	public partial class TenantVariableServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			var records = new List<TenantVariable>();
			records.Add(new TenantVariable());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			List<ApiTenantVariableResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			var record = new TenantVariable();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			ApiTenantVariableResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(null));
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			ApiTenantVariableResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			var model = new ApiTenantVariableRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TenantVariable>())).Returns(Task.FromResult(new TenantVariable()));
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			CreateResponse<ApiTenantVariableResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTenantVariableRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TenantVariable>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			var model = new ApiTenantVariableRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TenantVariable>())).Returns(Task.FromResult(new TenantVariable()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			UpdateResponse<ApiTenantVariableResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiTenantVariableRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TenantVariable>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			var model = new ApiTenantVariableRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByTenantIdOwnerIdEnvironmentIdVariableTemplateId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			var record = new TenantVariable();
			mock.RepositoryMock.Setup(x => x.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			ApiTenantVariableResponseModel response = await service.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(default(string), default(string), default(string), default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByTenantIdOwnerIdEnvironmentIdVariableTemplateId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			mock.RepositoryMock.Setup(x => x.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(null));
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			ApiTenantVariableResponseModel response = await service.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(default(string), default(string), default(string), default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByTenantId_Exists()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			var records = new List<TenantVariable>();
			records.Add(new TenantVariable());
			mock.RepositoryMock.Setup(x => x.ByTenantId(It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			List<ApiTenantVariableResponseModel> response = await service.ByTenantId(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTenantId(It.IsAny<string>()));
		}

		[Fact]
		public async void ByTenantId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITenantVariableRepository>();
			mock.RepositoryMock.Setup(x => x.ByTenantId(It.IsAny<string>())).Returns(Task.FromResult<List<TenantVariable>>(new List<TenantVariable>()));
			var service = new TenantVariableService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.TenantVariableModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLTenantVariableMapperMock,
			                                        mock.DALMapperMockFactory.DALTenantVariableMapperMock);

			List<ApiTenantVariableResponseModel> response = await service.ByTenantId(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTenantId(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>1781ea1564361045cf076a0035e4e848</Hash>
</Codenesium>*/