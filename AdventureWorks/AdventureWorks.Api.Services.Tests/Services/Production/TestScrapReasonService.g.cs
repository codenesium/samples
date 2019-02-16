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
	[Trait("Table", "ScrapReason")]
	[Trait("Area", "Services")]
	public partial class ScrapReasonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var records = new List<ScrapReason>();
			records.Add(new ScrapReason());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiScrapReasonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var record = new ScrapReason();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(record));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiScrapReasonServerResponseModel response = await service.Get(default(short));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ScrapReason>(null));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiScrapReasonServerResponseModel response = await service.Get(default(short));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var model = new ApiScrapReasonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ScrapReason>())).Returns(Task.FromResult(new ScrapReason()));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			CreateResponse<ApiScrapReasonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiScrapReasonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ScrapReason>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ScrapReasonCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var model = new ApiScrapReasonServerRequestModel();
			var validatorMock = new Mock<IApiScrapReasonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiScrapReasonServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			CreateResponse<ApiScrapReasonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiScrapReasonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ScrapReasonCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var model = new ApiScrapReasonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ScrapReason>())).Returns(Task.FromResult(new ScrapReason()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			UpdateResponse<ApiScrapReasonServerResponseModel> response = await service.Update(default(short), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiScrapReasonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ScrapReason>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ScrapReasonUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var model = new ApiScrapReasonServerRequestModel();
			var validatorMock = new Mock<IApiScrapReasonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiScrapReasonServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			UpdateResponse<ApiScrapReasonServerResponseModel> response = await service.Update(default(short), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiScrapReasonServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ScrapReasonUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var model = new ApiScrapReasonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.CompletedTask);
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ActionResponse response = await service.Delete(default(short));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<short>()));
			mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ScrapReasonDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var model = new ApiScrapReasonServerRequestModel();
			var validatorMock = new Mock<IApiScrapReasonServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<short>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ActionResponse response = await service.Delete(default(short));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<ScrapReasonDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var record = new ScrapReason();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiScrapReasonServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(null));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiScrapReasonServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void WorkOrdersByScrapReasonID_Exists()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var records = new List<WorkOrder>();
			records.Add(new WorkOrder());
			mock.RepositoryMock.Setup(x => x.WorkOrdersByScrapReasonID(default(short), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.WorkOrdersByScrapReasonID(default(short));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.WorkOrdersByScrapReasonID(default(short), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void WorkOrdersByScrapReasonID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			mock.RepositoryMock.Setup(x => x.WorkOrdersByScrapReasonID(default(short), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrder>>(new List<WorkOrder>()));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.WorkOrdersByScrapReasonID(default(short));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.WorkOrdersByScrapReasonID(default(short), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>98c2c1a591efe0b7d22fd43b6536b524</Hash>
</Codenesium>*/