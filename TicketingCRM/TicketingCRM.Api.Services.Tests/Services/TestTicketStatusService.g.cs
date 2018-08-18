using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "Services")]
	public partial class TicketStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var records = new List<TicketStatus>();
			records.Add(new TicketStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketStatusResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var record = new TicketStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketStatusResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TicketStatus>(null));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketStatusResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var model = new ApiTicketStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TicketStatus>())).Returns(Task.FromResult(new TicketStatus()));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			CreateResponse<ApiTicketStatusResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TicketStatus>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var model = new ApiTicketStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TicketStatus>())).Returns(Task.FromResult(new TicketStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			UpdateResponse<ApiTicketStatusResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TicketStatus>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var model = new ApiTicketStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Tickets_Exists()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			var records = new List<Ticket>();
			records.Add(new Ticket());
			mock.RepositoryMock.Setup(x => x.Tickets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketResponseModel> response = await service.Tickets(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Tickets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Tickets_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITicketStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Tickets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Ticket>>(new List<Ticket>()));
			var service = new TicketStatusService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.TicketStatusModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLTicketStatusMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketStatusMapperMock,
			                                      mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                      mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketResponseModel> response = await service.Tickets(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Tickets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>dbfeaa5fd0bcb277d704c4bb18d7e816</Hash>
</Codenesium>*/