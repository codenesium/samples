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
        [Trait("Table", "Tenant")]
        [Trait("Area", "Services")]
        public partial class TenantServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        var records = new List<Tenant>();
                        records.Add(new Tenant());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        List<ApiTenantResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        var record = new Tenant();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        ApiTenantResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Tenant>(null));
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        ApiTenantResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        var model = new ApiTenantRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tenant>())).Returns(Task.FromResult(new Tenant()));
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        CreateResponse<ApiTenantResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTenantRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Tenant>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        var model = new ApiTenantRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Tenant>())).Returns(Task.FromResult(new Tenant()));
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiTenantRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Tenant>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        var model = new ApiTenantRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Exists()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        var record = new Tenant();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        ApiTenantResponseModel response = await service.GetName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Tenant>(null));
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        ApiTenantResponseModel response = await service.GetName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetDataVersion_Exists()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        var records = new List<Tenant>();
                        records.Add(new Tenant());
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult(records));
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        List<ApiTenantResponseModel> response = await service.GetDataVersion(default(byte[]));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }

                [Fact]
                public async void GetDataVersion_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITenantRepository>();
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult<List<Tenant>>(new List<Tenant>()));
                        var service = new TenantService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TenantModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTenantMapperMock,
                                                        mock.DALMapperMockFactory.DALTenantMapperMock);

                        List<ApiTenantResponseModel> response = await service.GetDataVersion(default(byte[]));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }
        }
}

/*<Codenesium>
    <Hash>608fec86f9d559b687e563f4c8a120ca</Hash>
</Codenesium>*/