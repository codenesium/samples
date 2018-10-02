using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "Services")]
	public partial class EventStudentServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			var records = new List<EventStudent>();
			records.Add(new EventStudent());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			List<ApiEventStudentResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			var record = new EventStudent();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ApiEventStudentResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EventStudent>(null));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ApiEventStudentResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			var model = new ApiEventStudentRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStudent>())).Returns(Task.FromResult(new EventStudent()));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			CreateResponse<ApiEventStudentResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventStudentRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EventStudent>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			var model = new ApiEventStudentRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventStudent>())).Returns(Task.FromResult(new EventStudent()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventStudent()));
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			UpdateResponse<ApiEventStudentResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStudentRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EventStudent>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IEventStudentRepository>();
			var model = new ApiEventStudentRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EventStudentService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                      mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EventStudentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>83cd9de146b7cd3754b671de39f985ee</Hash>
</Codenesium>*/