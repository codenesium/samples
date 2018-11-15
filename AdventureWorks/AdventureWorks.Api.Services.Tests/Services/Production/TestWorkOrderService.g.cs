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
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "Services")]
	public partial class WorkOrderServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			var records = new List<WorkOrder>();
			records.Add(new WorkOrder());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			var record = new WorkOrder();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiWorkOrderServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<WorkOrder>(null));
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiWorkOrderServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			var model = new ApiWorkOrderServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkOrder>())).Returns(Task.FromResult(new WorkOrder()));
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			CreateResponse<ApiWorkOrderServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiWorkOrderServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<WorkOrder>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			var model = new ApiWorkOrderServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<WorkOrder>())).Returns(Task.FromResult(new WorkOrder()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new WorkOrder()));
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			UpdateResponse<ApiWorkOrderServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiWorkOrderServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<WorkOrder>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			var model = new ApiWorkOrderServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductID_Exists()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			var records = new List<WorkOrder>();
			records.Add(new WorkOrder());
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.ByProductID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrder>>(new List<WorkOrder>()));
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.ByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByScrapReasonID_Exists()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			var records = new List<WorkOrder>();
			records.Add(new WorkOrder());
			mock.RepositoryMock.Setup(x => x.ByScrapReasonID(It.IsAny<short?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.ByScrapReasonID(default(short));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByScrapReasonID(It.IsAny<short?>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByScrapReasonID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IWorkOrderRepository>();
			mock.RepositoryMock.Setup(x => x.ByScrapReasonID(It.IsAny<short?>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrder>>(new List<WorkOrder>()));
			var service = new WorkOrderService(mock.LoggerMock.Object,
			                                   mock.RepositoryMock.Object,
			                                   mock.ModelValidatorMockFactory.WorkOrderModelValidatorMock.Object,
			                                   mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                   mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderServerResponseModel> response = await service.ByScrapReasonID(default(short));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByScrapReasonID(It.IsAny<short?>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>9c204377d8fe04430657d04aa0997751</Hash>
</Codenesium>*/