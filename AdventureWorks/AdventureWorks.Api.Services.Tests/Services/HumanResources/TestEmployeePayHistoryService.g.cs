using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "EmployeePayHistory")]
        [Trait("Area", "Services")]
        public partial class EmployeePayHistoryServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IEmployeePayHistoryRepository>();
                        var records = new List<EmployeePayHistory>();
                        records.Add(new EmployeePayHistory());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EmployeePayHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.EmployeePayHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock);

                        List<ApiEmployeePayHistoryResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IEmployeePayHistoryRepository>();
                        var record = new EmployeePayHistory();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new EmployeePayHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.EmployeePayHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock);

                        ApiEmployeePayHistoryResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IEmployeePayHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EmployeePayHistory>(null));
                        var service = new EmployeePayHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.EmployeePayHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock);

                        ApiEmployeePayHistoryResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IEmployeePayHistoryRepository>();
                        var model = new ApiEmployeePayHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EmployeePayHistory>())).Returns(Task.FromResult(new EmployeePayHistory()));
                        var service = new EmployeePayHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.EmployeePayHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock);

                        CreateResponse<ApiEmployeePayHistoryResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EmployeePayHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeePayHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EmployeePayHistory>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IEmployeePayHistoryRepository>();
                        var model = new ApiEmployeePayHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EmployeePayHistory>())).Returns(Task.FromResult(new EmployeePayHistory()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EmployeePayHistory()));
                        var service = new EmployeePayHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.EmployeePayHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock);

                        UpdateResponse<ApiEmployeePayHistoryResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EmployeePayHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeePayHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EmployeePayHistory>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IEmployeePayHistoryRepository>();
                        var model = new ApiEmployeePayHistoryRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new EmployeePayHistoryService(mock.LoggerMock.Object,
                                                                    mock.RepositoryMock.Object,
                                                                    mock.ModelValidatorMockFactory.EmployeePayHistoryModelValidatorMock.Object,
                                                                    mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                                    mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.EmployeePayHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>727e885a799d3ab760a28f8b928d02f6</Hash>
</Codenesium>*/