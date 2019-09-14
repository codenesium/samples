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
	[Trait("Table", "Unit")]
	[Trait("Area", "Services")]
	public partial class UnitServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			var records = new List<Unit>();
			records.Add(new Unit());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			List<ApiUnitServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			var record = new Unit();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			ApiUnitServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Unit>(null));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			ApiUnitServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();

			var model = new ApiUnitServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Unit>())).Returns(Task.FromResult(new Unit()));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			CreateResponse<ApiUnitServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UnitModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUnitServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Unit>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			var model = new ApiUnitServerRequestModel();
			var validatorMock = new Mock<IApiUnitServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUnitServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			CreateResponse<ApiUnitServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiUnitServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			var model = new ApiUnitServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Unit>())).Returns(Task.FromResult(new Unit()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Unit()));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			UpdateResponse<ApiUnitServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.UnitModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Unit>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			var model = new ApiUnitServerRequestModel();
			var validatorMock = new Mock<IApiUnitServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Unit()));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			UpdateResponse<ApiUnitServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUnitServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			var model = new ApiUnitServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.UnitModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			var model = new ApiUnitServerRequestModel();
			var validatorMock = new Mock<IApiUnitServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<UnitDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CallAssignmentsByUnitId_Exists()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			var records = new List<CallAssignment>();
			records.Add(new CallAssignment());
			mock.RepositoryMock.Setup(x => x.CallAssignmentsByUnitId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			List<ApiCallAssignmentServerResponseModel> response = await service.CallAssignmentsByUnitId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CallAssignmentsByUnitId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CallAssignmentsByUnitId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			mock.RepositoryMock.Setup(x => x.CallAssignmentsByUnitId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<CallAssignment>>(new List<CallAssignment>()));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			List<ApiCallAssignmentServerResponseModel> response = await service.CallAssignmentsByUnitId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CallAssignmentsByUnitId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void UnitOfficersByUnitId_Exists()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			var records = new List<UnitOfficer>();
			records.Add(new UnitOfficer());
			mock.RepositoryMock.Setup(x => x.UnitOfficersByUnitId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			List<ApiUnitOfficerServerResponseModel> response = await service.UnitOfficersByUnitId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.UnitOfficersByUnitId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void UnitOfficersByUnitId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IUnitService, IUnitRepository>();
			mock.RepositoryMock.Setup(x => x.UnitOfficersByUnitId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<UnitOfficer>>(new List<UnitOfficer>()));
			var service = new UnitService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.UnitModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALUnitMapperMock,
			                              mock.DALMapperMockFactory.DALCallAssignmentMapperMock,
			                              mock.DALMapperMockFactory.DALUnitOfficerMapperMock);

			List<ApiUnitOfficerServerResponseModel> response = await service.UnitOfficersByUnitId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.UnitOfficersByUnitId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>80b24947c93b44870c257247ad80dcd5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/