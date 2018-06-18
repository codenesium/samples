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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DatabaseLog")]
        [Trait("Area", "Services")]
        public partial class DatabaseLogServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IDatabaseLogRepository>();
                        var records = new List<DatabaseLog>();
                        records.Add(new DatabaseLog());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new DatabaseLogService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
                                                             mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

                        List<ApiDatabaseLogResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IDatabaseLogRepository>();
                        var record = new DatabaseLog();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new DatabaseLogService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
                                                             mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

                        ApiDatabaseLogResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IDatabaseLogRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<DatabaseLog>(null));
                        var service = new DatabaseLogService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
                                                             mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

                        ApiDatabaseLogResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IDatabaseLogRepository>();
                        var model = new ApiDatabaseLogRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DatabaseLog>())).Returns(Task.FromResult(new DatabaseLog()));
                        var service = new DatabaseLogService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
                                                             mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

                        CreateResponse<ApiDatabaseLogResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDatabaseLogRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DatabaseLog>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IDatabaseLogRepository>();
                        var model = new ApiDatabaseLogRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DatabaseLog>())).Returns(Task.FromResult(new DatabaseLog()));
                        var service = new DatabaseLogService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
                                                             mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDatabaseLogRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DatabaseLog>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IDatabaseLogRepository>();
                        var model = new ApiDatabaseLogRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new DatabaseLogService(mock.LoggerMock.Object,
                                                             mock.RepositoryMock.Object,
                                                             mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Object,
                                                             mock.BOLMapperMockFactory.BOLDatabaseLogMapperMock,
                                                             mock.DALMapperMockFactory.DALDatabaseLogMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.DatabaseLogModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>cab331a5c2e98b2182b54fba42e94346</Hash>
</Codenesium>*/