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
	[Trait("Table", "Handler")]
	[Trait("Area", "Services")]
	public partial class HandlerServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var records = new List<Handler>();
			records.Add(new Handler());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock);

			List<ApiHandlerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var record = new Handler();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ApiHandlerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ApiHandlerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var model = new ApiHandlerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Handler>())).Returns(Task.FromResult(new Handler()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock);

			CreateResponse<ApiHandlerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Handler>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var model = new ApiHandlerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Handler>())).Returns(Task.FromResult(new Handler()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock);

			UpdateResponse<ApiHandlerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Handler>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var model = new ApiHandlerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void AirTransportsByHandlerId_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var records = new List<AirTransport>();
			records.Add(new AirTransport());
			mock.RepositoryMock.Setup(x => x.AirTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock);

			List<ApiAirTransportResponseModel> response = await service.AirTransportsByHandlerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.AirTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void AirTransportsByHandlerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			mock.RepositoryMock.Setup(x => x.AirTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<AirTransport>>(new List<AirTransport>()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock);

			List<ApiAirTransportResponseModel> response = await service.AirTransportsByHandlerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.AirTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>6994dc129e37c1ee09fc5175c55c76cd</Hash>
</Codenesium>*/