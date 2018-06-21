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
        [Trait("Table", "Shift")]
        [Trait("Area", "Services")]
        public partial class ShiftServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        var records = new List<Shift>();
                        records.Add(new Shift());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        List<ApiShiftResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        var record = new Shift();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ApiShiftResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Shift>(null));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ApiShiftResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        var model = new ApiShiftRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Shift>())).Returns(Task.FromResult(new Shift()));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        CreateResponse<ApiShiftResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiShiftRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Shift>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        var model = new ApiShiftRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Shift>())).Returns(Task.FromResult(new Shift()));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiShiftRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Shift>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        var model = new ApiShiftRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        var record = new Shift();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ApiShiftResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Shift>(null));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ApiShiftResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByStartTimeEndTime_Exists()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        var record = new Shift();
                        mock.RepositoryMock.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult(record));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ApiShiftResponseModel response = await service.ByStartTimeEndTime(default(TimeSpan), default(TimeSpan));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
                }

                [Fact]
                public async void ByStartTimeEndTime_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        mock.RepositoryMock.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(null));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        ApiShiftResponseModel response = await service.ByStartTimeEndTime(default(TimeSpan), default(TimeSpan));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
                }

                [Fact]
                public async void EmployeeDepartmentHistories_Exists()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        var records = new List<EmployeeDepartmentHistory>();
                        records.Add(new EmployeeDepartmentHistory());
                        mock.RepositoryMock.Setup(x => x.EmployeeDepartmentHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.EmployeeDepartmentHistories(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.EmployeeDepartmentHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void EmployeeDepartmentHistories_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IShiftRepository>();
                        mock.RepositoryMock.Setup(x => x.EmployeeDepartmentHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EmployeeDepartmentHistory>>(new List<EmployeeDepartmentHistory>()));
                        var service = new ShiftService(mock.LoggerMock.Object,
                                                       mock.RepositoryMock.Object,
                                                       mock.ModelValidatorMockFactory.ShiftModelValidatorMock.Object,
                                                       mock.BOLMapperMockFactory.BOLShiftMapperMock,
                                                       mock.DALMapperMockFactory.DALShiftMapperMock,
                                                       mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                       mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.EmployeeDepartmentHistories(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.EmployeeDepartmentHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>79b3d8115f5ace4bbf53072634c540a5</Hash>
</Codenesium>*/