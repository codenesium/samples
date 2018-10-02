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
	[Trait("Table", "Sysdiagram")]
	[Trait("Area", "Services")]
	public partial class SysdiagramServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISysdiagramRepository>();
			var records = new List<Sysdiagram>();
			records.Add(new Sysdiagram());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SysdiagramService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSysdiagramMapperMock,
			                                    mock.DALMapperMockFactory.DALSysdiagramMapperMock);

			List<ApiSysdiagramResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISysdiagramRepository>();
			var record = new Sysdiagram();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SysdiagramService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSysdiagramMapperMock,
			                                    mock.DALMapperMockFactory.DALSysdiagramMapperMock);

			ApiSysdiagramResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISysdiagramRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Sysdiagram>(null));
			var service = new SysdiagramService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSysdiagramMapperMock,
			                                    mock.DALMapperMockFactory.DALSysdiagramMapperMock);

			ApiSysdiagramResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISysdiagramRepository>();
			var model = new ApiSysdiagramRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Sysdiagram>())).Returns(Task.FromResult(new Sysdiagram()));
			var service = new SysdiagramService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSysdiagramMapperMock,
			                                    mock.DALMapperMockFactory.DALSysdiagramMapperMock);

			CreateResponse<ApiSysdiagramResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSysdiagramRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Sysdiagram>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISysdiagramRepository>();
			var model = new ApiSysdiagramRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Sysdiagram>())).Returns(Task.FromResult(new Sysdiagram()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sysdiagram()));
			var service = new SysdiagramService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSysdiagramMapperMock,
			                                    mock.DALMapperMockFactory.DALSysdiagramMapperMock);

			UpdateResponse<ApiSysdiagramResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSysdiagramRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Sysdiagram>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISysdiagramRepository>();
			var model = new ApiSysdiagramRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SysdiagramService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSysdiagramMapperMock,
			                                    mock.DALMapperMockFactory.DALSysdiagramMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByPrincipalIdName_Exists()
		{
			var mock = new ServiceMockFacade<ISysdiagramRepository>();
			var record = new Sysdiagram();
			mock.RepositoryMock.Setup(x => x.ByPrincipalIdName(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new SysdiagramService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSysdiagramMapperMock,
			                                    mock.DALMapperMockFactory.DALSysdiagramMapperMock);

			ApiSysdiagramResponseModel response = await service.ByPrincipalIdName(default(int), default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByPrincipalIdName(It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByPrincipalIdName_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISysdiagramRepository>();
			mock.RepositoryMock.Setup(x => x.ByPrincipalIdName(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Sysdiagram>(null));
			var service = new SysdiagramService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SysdiagramModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSysdiagramMapperMock,
			                                    mock.DALMapperMockFactory.DALSysdiagramMapperMock);

			ApiSysdiagramResponseModel response = await service.ByPrincipalIdName(default(int), default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByPrincipalIdName(It.IsAny<int>(), It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>3bb90ef5e403243567bb7da648ebdf0a</Hash>
</Codenesium>*/