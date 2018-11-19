using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
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
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			List<ApiEmployeeServerResponseModel> response = await service.All();

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
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ApiEmployeeServerResponseModel response = await service.Get(default(int));

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
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ApiEmployeeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Employee>())).Returns(Task.FromResult(new Employee()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			CreateResponse<ApiEmployeeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Employee>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeServerRequestModel();
			var validatorMock = new Mock<IApiEmployeeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			CreateResponse<ApiEmployeeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEmployeeServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Employee>())).Returns(Task.FromResult(new Employee()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			UpdateResponse<ApiEmployeeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Employee>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeServerRequestModel();
			var validatorMock = new Mock<IApiEmployeeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			UpdateResponse<ApiEmployeeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEmployeeServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var model = new ApiEmployeeServerRequestModel();
			var validatorMock = new Mock<IApiEmployeeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
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
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ApiEmployeeServerResponseModel response = await service.ByLoginID("test_value");

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
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ApiEmployeeServerResponseModel response = await service.ByLoginID("test_value");

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
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ApiEmployeeServerResponseModel response = await service.ByNationalIDNumber("test_value");

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
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ApiEmployeeServerResponseModel response = await service.ByNationalIDNumber("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByNationalIDNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void ByRowguid_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var record = new Employee();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ApiEmployeeServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByRowguid_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			mock.RepositoryMock.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Employee>(null));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			ApiEmployeeServerResponseModel response = await service.ByRowguid(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByRowguid(It.IsAny<Guid>()));
		}

		[Fact]
		public async void JobCandidatesByBusinessEntityID_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			var records = new List<JobCandidate>();
			records.Add(new JobCandidate());
			mock.RepositoryMock.Setup(x => x.JobCandidatesByBusinessEntityID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			List<ApiJobCandidateServerResponseModel> response = await service.JobCandidatesByBusinessEntityID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.JobCandidatesByBusinessEntityID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void JobCandidatesByBusinessEntityID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEmployeeRepository>();
			mock.RepositoryMock.Setup(x => x.JobCandidatesByBusinessEntityID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<JobCandidate>>(new List<JobCandidate>()));
			var service = new EmployeeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.EmployeeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLEmployeeMapperMock,
			                                  mock.DALMapperMockFactory.DALEmployeeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLJobCandidateMapperMock,
			                                  mock.DALMapperMockFactory.DALJobCandidateMapperMock);

			List<ApiJobCandidateServerResponseModel> response = await service.JobCandidatesByBusinessEntityID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.JobCandidatesByBusinessEntityID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>2d203d900fa63c28a7948eaa02360213</Hash>
</Codenesium>*/