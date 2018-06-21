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
        [Trait("Table", "Employee")]
        [Trait("Area", "Services")]
        public partial class EmployeeServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var records = new List<Employee>();
                        records.Add(new Employee());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiEmployeeResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var record = new Employee();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ApiEmployeeResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ApiEmployeeResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var model = new ApiEmployeeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Employee>())).Returns(Task.FromResult(new Employee()));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        CreateResponse<ApiEmployeeResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Employee>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var model = new ApiEmployeeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Employee>())).Returns(Task.FromResult(new Employee()));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Employee>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var model = new ApiEmployeeRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByLoginID_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var record = new Employee();
                        mock.RepositoryMock.Setup(x => x.ByLoginID(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ApiEmployeeResponseModel response = await service.ByLoginID(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByLoginID(It.IsAny<string>()));
                }

                [Fact]
                public async void ByLoginID_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        mock.RepositoryMock.Setup(x => x.ByLoginID(It.IsAny<string>())).Returns(Task.FromResult<Employee>(null));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ApiEmployeeResponseModel response = await service.ByLoginID(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByLoginID(It.IsAny<string>()));
                }

                [Fact]
                public async void ByNationalIDNumber_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var record = new Employee();
                        mock.RepositoryMock.Setup(x => x.ByNationalIDNumber(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ApiEmployeeResponseModel response = await service.ByNationalIDNumber(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByNationalIDNumber(It.IsAny<string>()));
                }

                [Fact]
                public async void ByNationalIDNumber_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        mock.RepositoryMock.Setup(x => x.ByNationalIDNumber(It.IsAny<string>())).Returns(Task.FromResult<Employee>(null));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        ApiEmployeeResponseModel response = await service.ByNationalIDNumber(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByNationalIDNumber(It.IsAny<string>()));
                }

                [Fact]
                public async void EmployeeDepartmentHistories_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var records = new List<EmployeeDepartmentHistory>();
                        records.Add(new EmployeeDepartmentHistory());
                        mock.RepositoryMock.Setup(x => x.EmployeeDepartmentHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.EmployeeDepartmentHistories(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.EmployeeDepartmentHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void EmployeeDepartmentHistories_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        mock.RepositoryMock.Setup(x => x.EmployeeDepartmentHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EmployeeDepartmentHistory>>(new List<EmployeeDepartmentHistory>()));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.EmployeeDepartmentHistories(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.EmployeeDepartmentHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void EmployeePayHistories_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var records = new List<EmployeePayHistory>();
                        records.Add(new EmployeePayHistory());
                        mock.RepositoryMock.Setup(x => x.EmployeePayHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiEmployeePayHistoryResponseModel> response = await service.EmployeePayHistories(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.EmployeePayHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void EmployeePayHistories_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        mock.RepositoryMock.Setup(x => x.EmployeePayHistories(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EmployeePayHistory>>(new List<EmployeePayHistory>()));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiEmployeePayHistoryResponseModel> response = await service.EmployeePayHistories(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.EmployeePayHistories(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void JobCandidates_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        var records = new List<JobCandidate>();
                        records.Add(new JobCandidate());
                        mock.RepositoryMock.Setup(x => x.JobCandidates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiJobCandidateResponseModel> response = await service.JobCandidates(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.JobCandidates(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void JobCandidates_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IEmployeeRepository>();
                        mock.RepositoryMock.Setup(x => x.JobCandidates(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<JobCandidate>>(new List<JobCandidate>()));
                        var service = new EmployeeService(mock.LoggerMock.Object,
                                                          mock.RepositoryMock.Object,
                                                          mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
                                                          mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLEmployeePayHistoryMapperMock,
                                                          mock.DALMapperMockFactory.DALEmployeePayHistoryMapperMock,
                                                          mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
                                                          mock.DALMapperMockFactory.DALJobCandidateMapperMock);

                        List<ApiJobCandidateResponseModel> response = await service.JobCandidates(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.JobCandidates(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>fc3a3e4c2c0e1a3d1cecc37c1df3c221</Hash>
</Codenesium>*/