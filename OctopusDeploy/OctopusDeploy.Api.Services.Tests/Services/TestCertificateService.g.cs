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
        [Trait("Table", "Certificate")]
        [Trait("Area", "Services")]
        public partial class CertificateServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        var records = new List<Certificate>();
                        records.Add(new Certificate());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        List<ApiCertificateResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        var record = new Certificate();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        ApiCertificateResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Certificate>(null));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        ApiCertificateResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        var model = new ApiCertificateRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Certificate>())).Returns(Task.FromResult(new Certificate()));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        CreateResponse<ApiCertificateResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCertificateRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Certificate>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        var model = new ApiCertificateRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Certificate>())).Returns(Task.FromResult(new Certificate()));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCertificateRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Certificate>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        var model = new ApiCertificateRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetCreated_Exists()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        var records = new List<Certificate>();
                        records.Add(new Certificate());
                        mock.RepositoryMock.Setup(x => x.GetCreated(It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(records));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        List<ApiCertificateResponseModel> response = await service.GetCreated(default(DateTimeOffset));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetCreated(It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetCreated_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        mock.RepositoryMock.Setup(x => x.GetCreated(It.IsAny<DateTimeOffset>())).Returns(Task.FromResult<List<Certificate>>(new List<Certificate>()));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        List<ApiCertificateResponseModel> response = await service.GetCreated(default(DateTimeOffset));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetCreated(It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetDataVersion_Exists()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        var records = new List<Certificate>();
                        records.Add(new Certificate());
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult(records));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        List<ApiCertificateResponseModel> response = await service.GetDataVersion(default(byte[]));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }

                [Fact]
                public async void GetDataVersion_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult<List<Certificate>>(new List<Certificate>()));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        List<ApiCertificateResponseModel> response = await service.GetDataVersion(default(byte[]));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }

                [Fact]
                public async void GetNotAfter_Exists()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        var records = new List<Certificate>();
                        records.Add(new Certificate());
                        mock.RepositoryMock.Setup(x => x.GetNotAfter(It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(records));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        List<ApiCertificateResponseModel> response = await service.GetNotAfter(default(DateTimeOffset));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetNotAfter(It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetNotAfter_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        mock.RepositoryMock.Setup(x => x.GetNotAfter(It.IsAny<DateTimeOffset>())).Returns(Task.FromResult<List<Certificate>>(new List<Certificate>()));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        List<ApiCertificateResponseModel> response = await service.GetNotAfter(default(DateTimeOffset));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetNotAfter(It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetThumbprint_Exists()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        var records = new List<Certificate>();
                        records.Add(new Certificate());
                        mock.RepositoryMock.Setup(x => x.GetThumbprint(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        List<ApiCertificateResponseModel> response = await service.GetThumbprint(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetThumbprint(It.IsAny<string>()));
                }

                [Fact]
                public async void GetThumbprint_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ICertificateRepository>();
                        mock.RepositoryMock.Setup(x => x.GetThumbprint(It.IsAny<string>())).Returns(Task.FromResult<List<Certificate>>(new List<Certificate>()));
                        var service = new CertificateService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.CertificateModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLCertificateMapperMock,
                                                             mock.DALMapperMockFactory.DALCertificateMapperMock);

                        List<ApiCertificateResponseModel> response = await service.GetThumbprint(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetThumbprint(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>575cadde11bb22fa12862b8ecd10dda0</Hash>
</Codenesium>*/