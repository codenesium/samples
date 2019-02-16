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
using System.Threading;
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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			List<ApiDepartmentServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var record = new Department();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(record));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			ApiDepartmentServerResponseModel response = await service.Get(default(short));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<Department>(null));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			ApiDepartmentServerResponseModel response = await service.Get(default(short));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var model = new ApiDepartmentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Department>())).Returns(Task.FromResult(new Department()));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			CreateResponse<ApiDepartmentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDepartmentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Department>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DepartmentCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var model = new ApiDepartmentServerRequestModel();
			var validatorMock = new Mock<IApiDepartmentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDepartmentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			CreateResponse<ApiDepartmentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDepartmentServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DepartmentCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var model = new ApiDepartmentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Department>())).Returns(Task.FromResult(new Department()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			UpdateResponse<ApiDepartmentServerResponseModel> response = await service.Update(default(short), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiDepartmentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Department>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DepartmentUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var model = new ApiDepartmentServerRequestModel();
			var validatorMock = new Mock<IApiDepartmentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiDepartmentServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Department()));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			UpdateResponse<ApiDepartmentServerResponseModel> response = await service.Update(default(short), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiDepartmentServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DepartmentUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var model = new ApiDepartmentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.CompletedTask);
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			ActionResponse response = await service.Delete(default(short));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<short>()));
			mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DepartmentDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var model = new ApiDepartmentServerRequestModel();
			var validatorMock = new Mock<IApiDepartmentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<short>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			ActionResponse response = await service.Delete(default(short));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DepartmentDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			var record = new Department();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			ApiDepartmentServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDepartmentRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Department>(null));
			var service = new DepartmentService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.DepartmentModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALDepartmentMapperMock);

			ApiDepartmentServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>1e6f909f5b20eea58ee2b9f20f8a684f</Hash>
</Codenesium>*/