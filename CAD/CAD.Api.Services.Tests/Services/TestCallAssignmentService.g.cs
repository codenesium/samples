using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallAssignment")]
	[Trait("Area", "Services")]
	public partial class CallAssignmentServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var records = new List<CallAssignment>();
			records.Add(new CallAssignment());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			List<ApiCallAssignmentServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var record = new CallAssignment();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			ApiCallAssignmentServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CallAssignment>(null));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			ApiCallAssignmentServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var model = new ApiCallAssignmentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallAssignment>())).Returns(Task.FromResult(new CallAssignment()));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			CreateResponse<ApiCallAssignmentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallAssignmentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CallAssignment>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallAssignmentCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var model = new ApiCallAssignmentServerRequestModel();
			var validatorMock = new Mock<IApiCallAssignmentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallAssignmentServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			CreateResponse<ApiCallAssignmentServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallAssignmentServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallAssignmentCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var model = new ApiCallAssignmentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallAssignment>())).Returns(Task.FromResult(new CallAssignment()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallAssignment()));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			UpdateResponse<ApiCallAssignmentServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallAssignmentServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CallAssignment>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallAssignmentUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var model = new ApiCallAssignmentServerRequestModel();
			var validatorMock = new Mock<IApiCallAssignmentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallAssignmentServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallAssignment()));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			UpdateResponse<ApiCallAssignmentServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallAssignmentServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallAssignmentUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var model = new ApiCallAssignmentServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallAssignmentDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var model = new ApiCallAssignmentServerRequestModel();
			var validatorMock = new Mock<IApiCallAssignmentServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallAssignmentDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByCallId_Exists()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var records = new List<CallAssignment>();
			records.Add(new CallAssignment());
			mock.RepositoryMock.Setup(x => x.ByCallId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			List<ApiCallAssignmentServerResponseModel> response = await service.ByCallId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCallId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByCallId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			mock.RepositoryMock.Setup(x => x.ByCallId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CallAssignment>>(new List<CallAssignment>()));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			List<ApiCallAssignmentServerResponseModel> response = await service.ByCallId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByCallId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUnitId_Exists()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			var records = new List<CallAssignment>();
			records.Add(new CallAssignment());
			mock.RepositoryMock.Setup(x => x.ByUnitId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			List<ApiCallAssignmentServerResponseModel> response = await service.ByUnitId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUnitId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByUnitId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICallAssignmentRepository>();
			mock.RepositoryMock.Setup(x => x.ByUnitId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CallAssignment>>(new List<CallAssignment>()));
			var service = new CallAssignmentService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.CallAssignmentModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALCallAssignmentMapperMock);

			List<ApiCallAssignmentServerResponseModel> response = await service.ByUnitId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByUnitId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>f1f12f5a8535e69ad109efe484b7d914</Hash>
</Codenesium>*/