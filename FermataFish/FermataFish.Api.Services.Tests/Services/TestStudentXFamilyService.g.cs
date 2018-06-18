using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "StudentXFamily")]
        [Trait("Area", "Services")]
        public partial class StudentXFamilyServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IStudentXFamilyRepository>();
                        var records = new List<StudentXFamily>();
                        records.Add(new StudentXFamily());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new StudentXFamilyService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.StudentXFamilyModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        List<ApiStudentXFamilyResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IStudentXFamilyRepository>();
                        var record = new StudentXFamily();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new StudentXFamilyService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.StudentXFamilyModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        ApiStudentXFamilyResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IStudentXFamilyRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<StudentXFamily>(null));
                        var service = new StudentXFamilyService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.StudentXFamilyModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        ApiStudentXFamilyResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IStudentXFamilyRepository>();
                        var model = new ApiStudentXFamilyRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<StudentXFamily>())).Returns(Task.FromResult(new StudentXFamily()));
                        var service = new StudentXFamilyService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.StudentXFamilyModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        CreateResponse<ApiStudentXFamilyResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.StudentXFamilyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStudentXFamilyRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<StudentXFamily>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IStudentXFamilyRepository>();
                        var model = new ApiStudentXFamilyRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<StudentXFamily>())).Returns(Task.FromResult(new StudentXFamily()));
                        var service = new StudentXFamilyService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.StudentXFamilyModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.StudentXFamilyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudentXFamilyRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<StudentXFamily>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IStudentXFamilyRepository>();
                        var model = new ApiStudentXFamilyRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new StudentXFamilyService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.StudentXFamilyModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLStudentXFamilyMapperMock,
                                                                mock.DALMapperMockFactory.DALStudentXFamilyMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.StudentXFamilyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>97230deeea59e0f7a30f802c56d10c44</Hash>
</Codenesium>*/