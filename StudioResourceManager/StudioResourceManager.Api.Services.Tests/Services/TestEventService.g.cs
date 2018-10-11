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
	[Trait("Table", "Event")]
	[Trait("Area", "Services")]
	public partial class EventServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			var records = new List<Event>();
			records.Add(new Event());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			var record = new Event();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ApiEventResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Event>(null));
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ApiEventResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			var model = new ApiEventRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Event>())).Returns(Task.FromResult(new Event()));
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			CreateResponse<ApiEventResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Event>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			var model = new ApiEventRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Event>())).Returns(Task.FromResult(new Event()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Event()));
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			UpdateResponse<ApiEventResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Event>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			var model = new ApiEventRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EventModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void EventStudents_Exists()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			var records = new List<EventStudent>();
			records.Add(new EventStudent());
			mock.RepositoryMock.Setup(x => x.EventStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventStudentResponseModel> response = await service.EventStudents(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStudents_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			mock.RepositoryMock.Setup(x => x.EventStudents(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventStudent>>(new List<EventStudent>()));
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventStudentResponseModel> response = await service.EventStudents(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStudents(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachers_Exists()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			var records = new List<EventTeacher>();
			records.Add(new EventTeacher());
			mock.RepositoryMock.Setup(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventTeacherResponseModel> response = await service.EventTeachers(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventTeachers_Not_Exists()
		{
			var mock = new ServiceMockFacade<IEventRepository>();
			mock.RepositoryMock.Setup(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventTeacher>>(new List<EventTeacher>()));
			var service = new EventService(mock.LoggerMock.Object,
			                               mock.RepositoryMock.Object,
			                               mock.ModelValidatorMockFactory.EventModelValidatorMock.Object,
			                               mock.BOLMapperMockFactory.BOLEventMapperMock,
			                               mock.DALMapperMockFactory.DALEventMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                               mock.DALMapperMockFactory.DALEventStudentMapperMock,
			                               mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                               mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventTeacherResponseModel> response = await service.EventTeachers(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventTeachers(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>4eb13f616116012245ef887da1bd8b2e</Hash>
</Codenesium>*/