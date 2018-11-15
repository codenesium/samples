using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatu")]
	[Trait("Area", "Services")]
	public partial class EventStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IEventStatuRepository>();
			var records = new List<EventStatu>();
			records.Add(new EventStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLEventStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALEventStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                    mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventStatuServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IEventStatuRepository>();
			var record = new EventStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EventStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLEventStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALEventStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                    mock.DALMapperMockFactory.DALEventMapperMock);

			ApiEventStatuServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IEventStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EventStatu>(null));
			var service = new EventStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLEventStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALEventStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                    mock.DALMapperMockFactory.DALEventMapperMock);

			ApiEventStatuServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IEventStatuRepository>();
			var model = new ApiEventStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStatu>())).Returns(Task.FromResult(new EventStatu()));
			var service = new EventStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLEventStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALEventStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                    mock.DALMapperMockFactory.DALEventMapperMock);

			CreateResponse<ApiEventStatuServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EventStatu>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IEventStatuRepository>();
			var model = new ApiEventStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStatu>())).Returns(Task.FromResult(new EventStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStatu()));
			var service = new EventStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLEventStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALEventStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                    mock.DALMapperMockFactory.DALEventMapperMock);

			UpdateResponse<ApiEventStatuServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EventStatu>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IEventStatuRepository>();
			var model = new ApiEventStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EventStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLEventStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALEventStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                    mock.DALMapperMockFactory.DALEventMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void EventsByEventStatusId_Exists()
		{
			var mock = new ServiceMockFacade<IEventStatuRepository>();
			var records = new List<Event>();
			records.Add(new Event());
			mock.RepositoryMock.Setup(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLEventStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALEventStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                    mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventServerResponseModel> response = await service.EventsByEventStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventsByEventStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEventStatuRepository>();
			mock.RepositoryMock.Setup(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Event>>(new List<Event>()));
			var service = new EventStatuService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.EventStatuModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLEventStatuMapperMock,
			                                    mock.DALMapperMockFactory.DALEventStatuMapperMock,
			                                    mock.BOLMapperMockFactory.BOLEventMapperMock,
			                                    mock.DALMapperMockFactory.DALEventMapperMock);

			List<ApiEventServerResponseModel> response = await service.EventsByEventStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventsByEventStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>b5f00e75a1aad75294f04638aad519d4</Hash>
</Codenesium>*/