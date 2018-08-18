using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "Services")]
	public partial class OtherTransportServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var records = new List<OtherTransport>();
			records.Add(new OtherTransport());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiOtherTransportResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var record = new OtherTransport();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiOtherTransportResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<OtherTransport>(null));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiOtherTransportResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var model = new ApiOtherTransportRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OtherTransport>())).Returns(Task.FromResult(new OtherTransport()));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			CreateResponse<ApiOtherTransportResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiOtherTransportRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<OtherTransport>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var model = new ApiOtherTransportRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<OtherTransport>())).Returns(Task.FromResult(new OtherTransport()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OtherTransport()));
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			UpdateResponse<ApiOtherTransportResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiOtherTransportRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<OtherTransport>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IOtherTransportRepository>();
			var model = new ApiOtherTransportRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new OtherTransportService(mock.LoggerMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Object,
			                                        mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                        mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.OtherTransportModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>0460ea83b4944acb1e18b87596fc7252</Hash>
</Codenesium>*/