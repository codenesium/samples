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
        [Trait("Table", "EmployeeDepartmentHistory")]
        [Trait("Area", "Services")]
        public partial class EmployeeDepartmentHistoryServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        var records = new List<EmployeeDepartmentHistory>();
                        records.Add(new EmployeeDepartmentHistory());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        var record = new EmployeeDepartmentHistory();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ApiEmployeeDepartmentHistoryResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EmployeeDepartmentHistory>(null));
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ApiEmployeeDepartmentHistoryResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        var model = new ApiEmployeeDepartmentHistoryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EmployeeDepartmentHistory>())).Returns(Task.FromResult(new EmployeeDepartmentHistory()));
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EmployeeDepartmentHistory>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        var model = new ApiEmployeeDepartmentHistoryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EmployeeDepartmentHistory>())).Returns(Task.FromResult(new EmployeeDepartmentHistory()));
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeDepartmentHistoryRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EmployeeDepartmentHistory>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        var model = new ApiEmployeeDepartmentHistoryRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByDepartmentID_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        var records = new List<EmployeeDepartmentHistory>();
                        records.Add(new EmployeeDepartmentHistory());
                        mock.RepositoryMock.Setup(x => x.ByDepartmentID(It.IsAny<short>())).Returns(Task.FromResult(records));
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.ByDepartmentID(default (short));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDepartmentID(It.IsAny<short>()));
                }

                [Fact]
                public async void ByDepartmentID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.ByDepartmentID(It.IsAny<short>())).Returns(Task.FromResult<List<EmployeeDepartmentHistory>>(new List<EmployeeDepartmentHistory>()));
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.ByDepartmentID(default (short));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDepartmentID(It.IsAny<short>()));
                }

                [Fact]
                public async void ByShiftID_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        var records = new List<EmployeeDepartmentHistory>();
                        records.Add(new EmployeeDepartmentHistory());
                        mock.RepositoryMock.Setup(x => x.ByShiftID(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.ByShiftID(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByShiftID(It.IsAny<int>()));
                }

                [Fact]
                public async void ByShiftID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeDepartmentHistoryRepository>();
                        mock.RepositoryMock.Setup(x => x.ByShiftID(It.IsAny<int>())).Returns(Task.FromResult<List<EmployeeDepartmentHistory>>(new List<EmployeeDepartmentHistory>()));
                        var service = new EmployeeDepartmentHistoryService(mock.LoggerMock.Object,
                                                                           mock.RepositoryMock.Object,
                                                                           mock.ModelValidatorMockFactory.EmployeeDepartmentHistoryModelValidatorMock.Object,
                                                                           mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                                           mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.ByShiftID(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByShiftID(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>60ba4ece35b2ecb3d60762e95a99f925</Hash>
</Codenesium>*/