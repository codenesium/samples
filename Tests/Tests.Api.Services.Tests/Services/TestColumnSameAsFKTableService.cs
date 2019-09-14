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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "Services")]
	public partial class ColumnSameAsFKTableServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableService, IColumnSameAsFKTableRepository>();
			var records = new List<ColumnSameAsFKTable>();
			records.Add(new ColumnSameAsFKTable());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			List<ApiColumnSameAsFKTableServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableService, IColumnSameAsFKTableRepository>();
			var record = new ColumnSameAsFKTable();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiColumnSameAsFKTableServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableService, IColumnSameAsFKTableRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<ColumnSameAsFKTable>(null));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ApiColumnSameAsFKTableServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableService, IColumnSameAsFKTableRepository>();

			var model = new ApiColumnSameAsFKTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ColumnSameAsFKTable>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			CreateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ColumnSameAsFKTable>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ColumnSameAsFKTableCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableService, IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			var validatorMock = new Mock<IApiColumnSameAsFKTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			CreateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ColumnSameAsFKTableCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableService, IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ColumnSameAsFKTable>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			UpdateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ColumnSameAsFKTable>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ColumnSameAsFKTableUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableService, IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			var validatorMock = new Mock<IApiColumnSameAsFKTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ColumnSameAsFKTable()));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			UpdateResponse<ApiColumnSameAsFKTableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiColumnSameAsFKTableServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ColumnSameAsFKTableUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableService, IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.ColumnSameAsFKTableModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ColumnSameAsFKTableDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IColumnSameAsFKTableService, IColumnSameAsFKTableRepository>();
			var model = new ApiColumnSameAsFKTableServerRequestModel();
			var validatorMock = new Mock<IApiColumnSameAsFKTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ColumnSameAsFKTableService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALColumnSameAsFKTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ColumnSameAsFKTableDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>b7272df2fdc44f3caccfc3a021a6825a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/