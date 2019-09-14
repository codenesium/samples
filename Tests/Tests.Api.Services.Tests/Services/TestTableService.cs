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
	[Trait("Table", "Table")]
	[Trait("Area", "Services")]
	public partial class TableServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITableService, ITableRepository>();
			var records = new List<Table>();
			records.Add(new Table());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			List<ApiTableServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITableService, ITableRepository>();
			var record = new Table();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			ApiTableServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ITableService, ITableRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Table>(null));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			ApiTableServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITableService, ITableRepository>();

			var model = new ApiTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Table>())).Returns(Task.FromResult(new Table()));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			CreateResponse<ApiTableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TableModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Table>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TableCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITableService, ITableRepository>();
			var model = new ApiTableServerRequestModel();
			var validatorMock = new Mock<IApiTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTableServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			CreateResponse<ApiTableServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTableServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TableCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITableService, ITableRepository>();
			var model = new ApiTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Table>())).Returns(Task.FromResult(new Table()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Table()));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			UpdateResponse<ApiTableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TableModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTableServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Table>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TableUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITableService, ITableRepository>();
			var model = new ApiTableServerRequestModel();
			var validatorMock = new Mock<IApiTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTableServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Table()));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			UpdateResponse<ApiTableServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTableServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TableUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITableService, ITableRepository>();
			var model = new ApiTableServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.TableModelValidatorMock.Object,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TableModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TableDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITableService, ITableRepository>();
			var model = new ApiTableServerRequestModel();
			var validatorMock = new Mock<IApiTableServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TableService(mock.LoggerMock.Object,
			                               mock.MediatorMock.Object,
			                               mock.RepositoryMock.Object,
			                               validatorMock.Object,
			                               mock.DALMapperMockFactory.DALTableMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TableDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>53fbd0a052fe854b4e84604504a60f8a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/