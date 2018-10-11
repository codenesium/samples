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
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "Services")]
	public partial class EventTeacherServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IEventTeacherRepository>();
			var records = new List<EventTeacher>();
			records.Add(new EventTeacher());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			List<ApiEventTeacherResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IEventTeacherRepository>();
			var record = new EventTeacher();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ApiEventTeacherResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IEventTeacherRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<EventTeacher>(null));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ApiEventTeacherResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IEventTeacherRepository>();
			var model = new ApiEventTeacherRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventTeacher>())).Returns(Task.FromResult(new EventTeacher()));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			CreateResponse<ApiEventTeacherResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiEventTeacherRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<EventTeacher>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IEventTeacherRepository>();
			var model = new ApiEventTeacherRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<EventTeacher>())).Returns(Task.FromResult(new EventTeacher()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EventTeacher()));
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			UpdateResponse<ApiEventTeacherResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventTeacherRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<EventTeacher>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IEventTeacherRepository>();
			var model = new ApiEventTeacherRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new EventTeacherService(mock.LoggerMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Object,
			                                      mock.BOLMapperMockFactory.BOLEventTeacherMapperMock,
			                                      mock.DALMapperMockFactory.DALEventTeacherMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.EventTeacherModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>852528a1a71278f4ba711a341155c946</Hash>
</Codenesium>*/