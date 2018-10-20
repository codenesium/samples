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
	[Trait("Table", "Student")]
	[Trait("Area", "Services")]
	public partial class StudentServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var records = new List<Student>();
			records.Add(new Student());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALEventStudentMapperMock);

			List<ApiStudentResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var record = new Student();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ApiStudentResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ApiStudentResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var model = new ApiStudentRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Student>())).Returns(Task.FromResult(new Student()));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALEventStudentMapperMock);

			CreateResponse<ApiStudentResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.StudentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiStudentRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Student>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var model = new ApiStudentRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Student>())).Returns(Task.FromResult(new Student()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALEventStudentMapperMock);

			UpdateResponse<ApiStudentResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.StudentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudentRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Student>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var model = new ApiStudentRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALEventStudentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.StudentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void EventStudentsByStudentId_Exists()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			var records = new List<EventStudent>();
			records.Add(new EventStudent());
			mock.RepositoryMock.Setup(x => x.EventStudentsByStudentId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALEventStudentMapperMock);

			List<ApiEventStudentResponseModel> response = await service.EventStudentsByStudentId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStudentsByStudentId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void EventStudentsByStudentId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IStudentRepository>();
			mock.RepositoryMock.Setup(x => x.EventStudentsByStudentId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<EventStudent>>(new List<EventStudent>()));
			var service = new StudentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.StudentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALStudentMapperMock,
			                                 mock.BOLMapperMockFactory.BOLEventStudentMapperMock,
			                                 mock.DALMapperMockFactory.DALEventStudentMapperMock);

			List<ApiEventStudentResponseModel> response = await service.EventStudentsByStudentId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.EventStudentsByStudentId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>818c4f4db84b70a978925dc25bf47d3b</Hash>
</Codenesium>*/