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
	[Trait("Table", "SalesPersonQuotaHistory")]
	[Trait("Area", "Services")]
	public partial class SalesPersonQuotaHistoryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISalesPersonQuotaHistoryRepository>();
			var records = new List<SalesPersonQuotaHistory>();
			records.Add(new SalesPersonQuotaHistory());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesPersonQuotaHistoryService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.SalesPersonQuotaHistoryModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
			                                                 mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock);

			List<ApiSalesPersonQuotaHistoryResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISalesPersonQuotaHistoryRepository>();
			var record = new SalesPersonQuotaHistory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SalesPersonQuotaHistoryService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.SalesPersonQuotaHistoryModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
			                                                 mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock);

			ApiSalesPersonQuotaHistoryResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISalesPersonQuotaHistoryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesPersonQuotaHistory>(null));
			var service = new SalesPersonQuotaHistoryService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.SalesPersonQuotaHistoryModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
			                                                 mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock);

			ApiSalesPersonQuotaHistoryResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISalesPersonQuotaHistoryRepository>();
			var model = new ApiSalesPersonQuotaHistoryRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesPersonQuotaHistory>())).Returns(Task.FromResult(new SalesPersonQuotaHistory()));
			var service = new SalesPersonQuotaHistoryService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.SalesPersonQuotaHistoryModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
			                                                 mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock);

			CreateResponse<ApiSalesPersonQuotaHistoryResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesPersonQuotaHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesPersonQuotaHistory>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISalesPersonQuotaHistoryRepository>();
			var model = new ApiSalesPersonQuotaHistoryRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesPersonQuotaHistory>())).Returns(Task.FromResult(new SalesPersonQuotaHistory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesPersonQuotaHistory()));
			var service = new SalesPersonQuotaHistoryService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.SalesPersonQuotaHistoryModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
			                                                 mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock);

			UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesPersonQuotaHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesPersonQuotaHistoryRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesPersonQuotaHistory>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISalesPersonQuotaHistoryRepository>();
			var model = new ApiSalesPersonQuotaHistoryRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SalesPersonQuotaHistoryService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.SalesPersonQuotaHistoryModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLSalesPersonQuotaHistoryMapperMock,
			                                                 mock.DALMapperMockFactory.DALSalesPersonQuotaHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SalesPersonQuotaHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>71796a42d84d3d967d293d1ff3ee01da</Hash>
</Codenesium>*/