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
	[Trait("Table", "SalesOrderHeaderSalesReason")]
	[Trait("Area", "Services")]
	public partial class SalesOrderHeaderSalesReasonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISalesOrderHeaderSalesReasonRepository>();
			var records = new List<SalesOrderHeaderSalesReason>();
			records.Add(new SalesOrderHeaderSalesReason());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesOrderHeaderSalesReasonService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.SalesOrderHeaderSalesReasonModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
			                                                     mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

			List<ApiSalesOrderHeaderSalesReasonResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISalesOrderHeaderSalesReasonRepository>();
			var record = new SalesOrderHeaderSalesReason();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SalesOrderHeaderSalesReasonService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.SalesOrderHeaderSalesReasonModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
			                                                     mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

			ApiSalesOrderHeaderSalesReasonResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISalesOrderHeaderSalesReasonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesOrderHeaderSalesReason>(null));
			var service = new SalesOrderHeaderSalesReasonService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.SalesOrderHeaderSalesReasonModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
			                                                     mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

			ApiSalesOrderHeaderSalesReasonResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISalesOrderHeaderSalesReasonRepository>();
			var model = new ApiSalesOrderHeaderSalesReasonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesOrderHeaderSalesReason>())).Returns(Task.FromResult(new SalesOrderHeaderSalesReason()));
			var service = new SalesOrderHeaderSalesReasonService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.SalesOrderHeaderSalesReasonModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
			                                                     mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

			CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesOrderHeaderSalesReasonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesOrderHeaderSalesReason>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISalesOrderHeaderSalesReasonRepository>();
			var model = new ApiSalesOrderHeaderSalesReasonRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesOrderHeaderSalesReason>())).Returns(Task.FromResult(new SalesOrderHeaderSalesReason()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeaderSalesReason()));
			var service = new SalesOrderHeaderSalesReasonService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.SalesOrderHeaderSalesReasonModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
			                                                     mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

			UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesOrderHeaderSalesReasonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesOrderHeaderSalesReasonRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesOrderHeaderSalesReason>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISalesOrderHeaderSalesReasonRepository>();
			var model = new ApiSalesOrderHeaderSalesReasonRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SalesOrderHeaderSalesReasonService(mock.LoggerMock.Object,
			                                                     mock.RepositoryMock.Object,
			                                                     mock.ModelValidatorMockFactory.SalesOrderHeaderSalesReasonModelValidatorMock.Object,
			                                                     mock.BOLMapperMockFactory.BOLSalesOrderHeaderSalesReasonMapperMock,
			                                                     mock.DALMapperMockFactory.DALSalesOrderHeaderSalesReasonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SalesOrderHeaderSalesReasonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>56f6ba5ee640dd2662e65d57ba77d35c</Hash>
</Codenesium>*/