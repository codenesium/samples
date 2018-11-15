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
	[Trait("Table", "Ticket")]
	[Trait("Area", "Services")]
	public partial class TicketServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var records = new List<Ticket>();
			records.Add(new Ticket());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var record = new Ticket();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var model = new ApiTicketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Ticket>())).Returns(Task.FromResult(new Ticket()));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                mock.DALMapperMockFactory.DALTicketMapperMock);

			CreateResponse<ApiTicketServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TicketModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Ticket>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var model = new ApiTicketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Ticket>())).Returns(Task.FromResult(new Ticket()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                mock.DALMapperMockFactory.DALTicketMapperMock);

			UpdateResponse<ApiTicketServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TicketModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Ticket>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var model = new ApiTicketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                mock.DALMapperMockFactory.DALTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TicketModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByTicketStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			var records = new List<Ticket>();
			records.Add(new Ticket());
			mock.RepositoryMock.Setup(x => x.ByTicketStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketServerResponseModel> response = await service.ByTicketStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTicketStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITicketRepository>();
			mock.RepositoryMock.Setup(x => x.ByTicketStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Ticket>>(new List<Ticket>()));
			var service = new TicketService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketServerResponseModel> response = await service.ByTicketStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>ba51e5a571910c1c6838dced73d9b786</Hash>
</Codenesium>*/