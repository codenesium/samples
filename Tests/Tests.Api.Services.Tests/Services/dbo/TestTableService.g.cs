using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Table")]
        [Trait("Area", "Services")]
        public partial class TableServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ITableRepository>();
                        var records = new List<Table>();
                        records.Add(new Table());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TableService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLTableMapperMock,
                                                       mock.DALMapperMockFactory.DALTableMapperMock);

                        List<ApiTableResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ITableRepository>();
                        var record = new Table();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new TableService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLTableMapperMock,
                                                       mock.DALMapperMockFactory.DALTableMapperMock);

                        ApiTableResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ITableRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Table>(null));
                        var service = new TableService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLTableMapperMock,
                                                       mock.DALMapperMockFactory.DALTableMapperMock);

                        ApiTableResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ITableRepository>();
                        var model = new ApiTableRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Table>())).Returns(Task.FromResult(new Table()));
                        var service = new TableService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLTableMapperMock,
                                                       mock.DALMapperMockFactory.DALTableMapperMock);

                        CreateResponse<ApiTableResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TableModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTableRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Table>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ITableRepository>();
                        var model = new ApiTableRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Table>())).Returns(Task.FromResult(new Table()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Table()));
                        var service = new TableService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLTableMapperMock,
                                                       mock.DALMapperMockFactory.DALTableMapperMock);

                        UpdateResponse<ApiTableResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TableModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTableRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Table>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ITableRepository>();
                        var model = new ApiTableRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new TableService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLTableMapperMock,
                                                       mock.DALMapperMockFactory.DALTableMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.TableModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>e32c9bf78aaba908710ab7a0323e0c8c</Hash>
</Codenesium>*/