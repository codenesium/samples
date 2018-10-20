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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiScrapReasonResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var record = new ScrapReason();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(record));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiScrapReasonResponseModel response = await service.Get(default(short));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult<ScrapReason>(null));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiScrapReasonResponseModel response = await service.Get(default(short));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<short>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var model = new ApiScrapReasonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ScrapReason>())).Returns(Task.FromResult(new ScrapReason()));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			CreateResponse<ApiScrapReasonResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiScrapReasonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ScrapReason>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var model = new ApiScrapReasonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ScrapReason>())).Returns(Task.FromResult(new ScrapReason()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			UpdateResponse<ApiScrapReasonResponseModel> response = await service.Update(default(short), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<short>(), It.IsAny<ApiScrapReasonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ScrapReason>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var model = new ApiScrapReasonRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<short>())).Returns(Task.CompletedTask);
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ActionResponse response = await service.Delete(default(short));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<short>()));
			mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<short>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			var record = new ScrapReason();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiScrapReasonResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(null));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			ApiScrapReasonResponseModel response = await service.ByName(default(string));

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
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderResponseModel> response = await service.WorkOrdersByScrapReasonID(default(short));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.WorkOrdersByScrapReasonID(default(short), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void WorkOrdersByScrapReasonID_Not_Exists()
		{
			var mock = new ServiceMockFacade<IScrapReasonRepository>();
			mock.RepositoryMock.Setup(x => x.WorkOrdersByScrapReasonID(default(short), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<WorkOrder>>(new List<WorkOrder>()));
			var service = new ScrapReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.ScrapReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLScrapReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALScrapReasonMapperMock,
			                                     mock.BOLMapperMockFactory.BOLWorkOrderMapperMock,
			                                     mock.DALMapperMockFactory.DALWorkOrderMapperMock);

			List<ApiWorkOrderResponseModel> response = await service.WorkOrdersByScrapReasonID(default(short));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.WorkOrdersByScrapReasonID(default(short), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a4774ad2e39d5427c482dc90ca91a83f</Hash>
</Codenesium>*/