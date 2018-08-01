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
	[Trait("Table", "Department")]
	[Trait("Area", "Services")]
	public partial class DepartmentServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var records = new List<Department>();
			records.Add(new Department());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			List<ApiDepartmentResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var record = new Department();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(record));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			ApiDepartmentResponseModel response = await service.Get(default(short));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<Department>(null));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			ApiDepartmentResponseModel response = await service.Get(default(short));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var model = new ApiDepartmentRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Department>())).Returns(Task.FromResult(new Department()));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			CreateResponse<ApiDepartmentResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDepartmentRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Department>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var model = new ApiDepartmentRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Department>())).Returns(Task.FromResult(new Department()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			UpdateResponse<ApiDepartmentResponseModel> response = await service.Update(default(short), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiDepartmentRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Department>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var model = new ApiDepartmentRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.CompletedTask);
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			ActionResponse response = await service.Delete(default(short));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<short>()));
			mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var record = new Department();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			ApiDepartmentResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Department>(null));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			ApiDepartmentResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void EmployeeDepartmentHistories_Exists()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var records = new List<EmployeeDepartmentHistory>();
			records.Add(new EmployeeDepartmentHistory());
			mock.RepositoryMock.Setup(x => x.EmployeeDepartmentHistories(default(short), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.EmployeeDepartmentHistories(default(short));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EmployeeDepartmentHistories(default(short), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EmployeeDepartmentHistories_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			mock.RepositoryMock.Setup(x => x.EmployeeDepartmentHistories(default(short), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EmployeeDepartmentHistory>>(new List<EmployeeDepartmentHistory>()));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLDepartmentMapperMock,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEmployeeDepartmentHistoryMapperMock,
			                                    mock.DALMapperMockFactory.DALEmployeeDepartmentHistoryMapperMock);

			List<ApiEmployeeDepartmentHistoryResponseModel> response = await service.EmployeeDepartmentHistories(default(short));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EmployeeDepartmentHistories(default(short), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>efd648a33b5bbf935d386e324477abe6</Hash>
</Codenesium>*/