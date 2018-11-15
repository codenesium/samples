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
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiHandlerServerResponseModel> response = await service.All();

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
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiHandlerServerResponseModel response = await service.Get(default(int));

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
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiHandlerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var model = new ApiHandlerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Handler>())).Returns(Task.FromResult(new Handler()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			CreateResponse<ApiHandlerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Handler>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var model = new ApiHandlerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Handler>())).Returns(Task.FromResult(new Handler()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			UpdateResponse<ApiHandlerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Handler>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var model = new ApiHandlerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

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
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiAirTransportServerResponseModel> response = await service.AirTransportsByHandlerId(default(int));

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
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiAirTransportServerResponseModel> response = await service.AirTransportsByHandlerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.AirTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void HandlerPipelineStepsByHandlerId_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var records = new List<HandlerPipelineStep>();
			records.Add(new HandlerPipelineStep());
			mock.RepositoryMock.Setup(x => x.HandlerPipelineStepsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiHandlerPipelineStepServerResponseModel> response = await service.HandlerPipelineStepsByHandlerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.HandlerPipelineStepsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void HandlerPipelineStepsByHandlerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			mock.RepositoryMock.Setup(x => x.HandlerPipelineStepsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<HandlerPipelineStep>>(new List<HandlerPipelineStep>()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiHandlerPipelineStepServerResponseModel> response = await service.HandlerPipelineStepsByHandlerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.HandlerPipelineStepsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OtherTransportsByHandlerId_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			var records = new List<OtherTransport>();
			records.Add(new OtherTransport());
			mock.RepositoryMock.Setup(x => x.OtherTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiOtherTransportServerResponseModel> response = await service.OtherTransportsByHandlerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.OtherTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OtherTransportsByHandlerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerRepository>();
			mock.RepositoryMock.Setup(x => x.OtherTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<OtherTransport>>(new List<OtherTransport>()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.BOLMapperMockFactory.BOLAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.BOLMapperMockFactory.BOLHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.BOLMapperMockFactory.BOLOtherTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiOtherTransportServerResponseModel> response = await service.OtherTransportsByHandlerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.OtherTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>4245922ad40f5d8c8f5c8727dd135b4f</Hash>
</Codenesium>*/