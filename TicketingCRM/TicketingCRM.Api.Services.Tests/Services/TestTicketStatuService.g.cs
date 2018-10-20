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
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "Services")]
	public partial class TicketStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var records = new List<TicketStatu>();
			records.Add(new TicketStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketStatuResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var record = new TicketStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketStatuResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(null));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			ApiTicketStatuResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var model = new ApiTicketStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TicketStatu>())).Returns(Task.FromResult(new TicketStatu()));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			CreateResponse<ApiTicketStatuResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TicketStatu>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var model = new ApiTicketStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TicketStatu>())).Returns(Task.FromResult(new TicketStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatu()));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			UpdateResponse<ApiTicketStatuResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TicketStatu>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var model = new ApiTicketStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void TicketsByTicketStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			var records = new List<Ticket>();
			records.Add(new Ticket());
			mock.RepositoryMock.Setup(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketResponseModel> response = await service.TicketsByTicketStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void TicketsByTicketStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITicketStatuRepository>();
			mock.RepositoryMock.Setup(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Ticket>>(new List<Ticket>()));
			var service = new TicketStatuService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TicketStatuModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTicketStatuMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketStatuMapperMock,
			                                     mock.BOLMapperMockFactory.BOLTicketMapperMock,
			                                     mock.DALMapperMockFactory.DALTicketMapperMock);

			List<ApiTicketResponseModel> response = await service.TicketsByTicketStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.TicketsByTicketStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>724dd5b6809c88cafc999a89600d9db2</Hash>
</Codenesium>*/