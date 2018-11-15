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
	[Trait("Table", "AirTransport")]
	[Trait("Area", "Services")]
	public partial class AirTransportServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var records = new List<AirTransport>();
			records.Add(new AirTransport());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			List<ApiAirTransportServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var record = new AirTransport();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ApiAirTransportServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<AirTransport>(null));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ApiAirTransportServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var model = new ApiAirTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AirTransport>())).Returns(Task.FromResult(new AirTransport()));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			CreateResponse<ApiAirTransportServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiAirTransportServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<AirTransport>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var model = new ApiAirTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<AirTransport>())).Returns(Task.FromResult(new AirTransport()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AirTransport()));
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			UpdateResponse<ApiAirTransportServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAirTransportServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<AirTransport>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IAirTransportRepository>();
			var model = new ApiAirTransportServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new AirTransportService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.AirTransportModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d4b30085948bbbafe2a57a181696f16a</Hash>
</Codenesium>*/