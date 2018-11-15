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
	[Trait("Table", "SalesReason")]
	[Trait("Area", "Services")]
	public partial class SalesReasonServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var records = new List<SalesReason>();
			records.Add(new SalesReason());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			List<ApiSalesReasonServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var record = new SalesReason();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			ApiSalesReasonServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(null));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			ApiSalesReasonServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var model = new ApiSalesReasonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesReason>())).Returns(Task.FromResult(new SalesReason()));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			CreateResponse<ApiSalesReasonServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSalesReasonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SalesReason>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var model = new ApiSalesReasonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SalesReason>())).Returns(Task.FromResult(new SalesReason()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesReason()));
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			UpdateResponse<ApiSalesReasonServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSalesReasonServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SalesReason>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISalesReasonRepository>();
			var model = new ApiSalesReasonServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SalesReasonService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSalesReasonMapperMock,
			                                     mock.DALMapperMockFactory.DALSalesReasonMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SalesReasonModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>1fedc51c0fd709081cebb3643bb3056b</Hash>
</Codenesium>*/